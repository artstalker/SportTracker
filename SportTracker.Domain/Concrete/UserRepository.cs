using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

using SportTracker.Domain.Abstract;
using SportTracker.Domain.Entities;

namespace SportTracker.Domain.Concrete
{
	public class UserRepository : BaseRepository, IUserRepository
	{

		private readonly IConfigService configService;
		private readonly IEmailService emailService;

		public UserRepository(IConfigService configService, IEmailService emailService)
		{
			this.configService = configService;
			this.emailService = emailService;
		}

		#region Implementation of IUserRepository
		public IQueryable<User> Entities
		{
			get
			{
				//SqlConnection.ClearAllPools();
				//var _container = new ModelSportTrackerContainer(Connection.ConnectionStringName);
				//_container.Database.Initialize(false);
				return _container.Users.Include("BodyStamps").Include("Friends").Include("Programs").Include("Tweets").Include("Trainings");
			}
		}

		public void Save(User entity)
		{
			if (entity.UserId <= 0)
			{
				_container.Users.Add(entity);
			}
			_container.SaveChanges();
		}


		public void Add(User user)
		{
			_container.Users.Add(user);
		}

		public void Update(User user)
		{
			_container.Users.Attach(user);
			_container.Entry(user).State = EntityState.Modified;
			_container.ChangeTracker.DetectChanges();

		}
		#endregion

		public User GetUserProfile(string userName)
		{
			return Entities.FirstOrDefault(x => x.Email.Equals(userName));
		}

		public User GetUserProfile(int userId)
		{
			return Entities.FirstOrDefault(x => x.UserId.Equals(userId));

		}

		OAuthMembership IUserRepository.GetOAuthMembership(string provider, string providerUserId)
		{
			return _container.OAuthMemberships.FirstOrDefault(x => x.Provider.Equals(provider) && x.ProviderUserId.Equals(providerUserId));
		}

		void IUserRepository.SaveOAuthMembership(string provider, string providerUserId, int userId)
		{
			var oAuthMembership = _container.OAuthMemberships.FirstOrDefault(x => x.Provider.Equals(provider) && x.ProviderUserId.Equals(providerUserId));
			if (oAuthMembership == null)
			{
				oAuthMembership = new OAuthMembership { Provider = provider, ProviderUserId = providerUserId };
				_container.OAuthMemberships.Add(oAuthMembership);
			}
			oAuthMembership.UserId = userId;
			_container.SaveChanges();
		}

		Membership IUserRepository.GetMembership(int userId)
		{
			return _container.Memberships.FirstOrDefault(x => x.UserId == userId);
		}

		Membership IUserRepository.GetMembershipByConfirmToken(string token, bool withUserProfile)
		{
			var membership = _container.Memberships.FirstOrDefault(x => x.ConfirmationToken.Equals(token.ToLower()));
			if (membership != null && withUserProfile)
			{
				membership.User = Entities.First(x => x.UserId == membership.UserId);
			}
			return membership;
		}

		Membership IUserRepository.GetMembershipByVerificationToken(string token, bool withUserProfile)
		{
			var membership = _container.Memberships.FirstOrDefault(x => x.PasswordVerificationToken.Equals(token.ToLower()));
			if (membership != null && withUserProfile)
			{
				membership.User = Entities.First(x => x.UserId == membership.UserId);
			}
			return membership;
		}

		void IUserRepository.Save(Membership membership, bool add)
		{
			if (add)
			{
				_container.Memberships.Add(membership);
			}
			_container.SaveChanges();
		}

		// to do: transfer it to service
		void IUserRepository.SendAccountActivationMail(string email)
		{
			var userProfile = (this as IUserRepository).GetUserProfile(email);
			if (userProfile == null)
			{
				throw new MembershipCreateUserException(MembershipCreateStatus.ProviderError);
			}

			var membership = (this as IUserRepository).GetMembership(userProfile.UserId);
			if (membership == null)
			{
				throw new MembershipCreateUserException(MembershipCreateStatus.ProviderError);
			}

			var configValues = this.configService.GetValues(new ConfigName[] { ConfigName.WebsiteUrlName, ConfigName.WebsiteTitle, ConfigName.WebsiteUrl });
			var viewData = new ViewDataDictionary { Model = userProfile };
			viewData.Add("Membership", membership);
			this.emailService.SendEmail(
				 new SendEmailModel
				 {
					 EmailAddress = email,
					 Subject = configValues[ConfigName.WebsiteUrlName.ToString()] + ": Confirm your registration",
					 WebsiteUrlName = configValues[ConfigName.WebsiteUrlName.ToString()],
					 WebsiteTitle = configValues[ConfigName.WebsiteTitle.ToString()],
					 WebsiteURL = configValues[ConfigName.WebsiteUrl.ToString()]
				 },
				 "ConfirmRegistration",
				 viewData
			);
		}

		string[] IUserRepository.GetRoles(string userName)
		{
			var userProfile = Entities.FirstOrDefault(x => x.Name.Equals(userName));
			if (userProfile != null)
			{
				return userProfile.Roles.Select(x => x.RoleName).ToArray();
			}
			return new string[] { };
		}

		void IUserRepository.SentChangePasswordEmail(string email)
		{
			var userProfile = (this as IUserRepository).GetUserProfile(email);
			if (userProfile == null)
			{
				throw new MembershipCreateUserException("User not found.");
			}

			var membership = (this as IUserRepository).GetMembership(userProfile.UserId);
			if (membership == null)
			{
				throw new MembershipCreateUserException("User not found.");
			}

			membership.PasswordVerificationToken = Guid.NewGuid().ToString();
			_container.SaveChanges();

			var configValues = this.configService.GetValues(new ConfigName[] { ConfigName.WebsiteUrlName, ConfigName.WebsiteTitle, ConfigName.WebsiteUrl });
			var viewData = new ViewDataDictionary { Model = membership };
			emailService.SendEmail(
				 new SendEmailModel
				 {
					 EmailAddress = email,
					 Subject = configValues[ConfigName.WebsiteUrlName.ToString()] + ": Change password.",
					 WebsiteUrlName = configValues[ConfigName.WebsiteUrlName.ToString()],
					 WebsiteTitle = configValues[ConfigName.WebsiteTitle.ToString()],
					 WebsiteURL = configValues[ConfigName.WebsiteUrl.ToString()]
				 },
				 "ChangePassword",
				 viewData
			);
		}

		private string salt = "HJIO6589";
		string IUserRepository.GetHash(string text)
		{
			var buffer = Encoding.UTF8.GetBytes(String.Concat(text, salt));
			var cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
			string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
			return hash;
		}


		void IUserRepository.ChangePassword(Membership membership, string newPassword)
		{
			if (membership == null)
			{
				throw new Exception("User not found.");
			}

			membership.PasswordVerificationToken = null;
			membership.PasswordSalt = (this as IUserRepository).GetHash(newPassword);

			_container.SaveChanges();
		}
	}
}
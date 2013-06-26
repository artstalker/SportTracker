using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTracker.Domain.SampleData
{
	public class EntitiesContextInitializer : DropCreateDatabaseAlways<ModelSportTrackerContainer>
	{
		protected override void Seed(ModelSportTrackerContainer context)
		{
			PopulateRoles(context);
			PopulateConfigs(context);
			PopulateUsers(context);
			PopulateMembership(context);
		}

		

		private void PopulateConfigs(ModelSportTrackerContainer context)
		{
			List<Config> configs = new List<Config>
				{
					new Config(){Key="WebsiteTitle", Value = "SportTracker"},
					new Config(){Key="WebsiteUrl", Value = "http://localhost:28255"},
					new Config(){Key="WebsiteUrlName", Value = "URL"},
				};


			foreach (Config r in configs)
			{
				context.Configs.Add(r);
			}
			
		}

		private void PopulateRoles(ModelSportTrackerContainer context)
		{
			List<Role> roles = new List<Role> { new Role { RoleName = "Admin" }, new Role { RoleName = "User" }, };

			// add data into context and save to db
			foreach (Role r in roles)
			{
				context.Roles.Add(r);
			}
			context.SaveChanges();
		}

		private void PopulateUsers(ModelSportTrackerContainer context)
		{
			User user = new User() { Email = "groshevoy@gmail.com", Name = "groshevoy@gmail.com" };
			user.Roles.Add(context.Roles.First(x => x.RoleName == "Admin"));
			
			context.Users.Add(user);
			context.SaveChanges();
		}

		private void PopulateMembership(ModelSportTrackerContainer context)
		{
			Membership membership = new Membership()
				{
					CreateDate = DateTime.Parse("13.06.2013 16:53:16"),
					IsConfirmed = true,
					PasswordSalt = "0DE5558BFFDFF421FD936C9E0EFCA1E9B2D41302"
				};
			membership.User = context.Users.First();
			membership.UserId = membership.User.UserId;
			context.Memberships.Add(membership);
			
		}
	}
}

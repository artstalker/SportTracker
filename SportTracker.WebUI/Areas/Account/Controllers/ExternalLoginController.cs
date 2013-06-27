using System.Web.Mvc;

using DotNetOpenAuth.AspNet;

using Microsoft.Web.WebPages.OAuth;

using SportTracker.Domain;
using SportTracker.Domain.Abstract;
using SportTracker.Domain.Entities;
using SportTracker.WebUI.Areas.Account.Models;

namespace SportTracker.WebUI.Areas.Account.Controllers
{
	public class ExternalLoginController : Controller
	{
		private readonly IUserRepository usersService;

		public ExternalLoginController(IUserRepository usersService)
		{
			this.usersService = usersService;
		}

		//
		// POST: /Account/ExternalLogin/

		[HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
		public ActionResult Index(string provider, string returnUrl)
		{
			return new ExternalLoginResult(provider, Url.Action("Callback", new { ReturnUrl = returnUrl }));
		}

		//
		// GET: /Account/ExternalLogin/Callback

		[AllowAnonymous]
		public ActionResult Callback(string returnUrl)
		{
			AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("Callback", new { ReturnUrl = returnUrl }));
			if (!result.IsSuccessful)
			{
				return RedirectToAction("Failure");
			}

			if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
			{
				return RedirectToLocal(returnUrl);
			}

			if (User.Identity.IsAuthenticated)
			{
				// If the current user is logged in add the new account
				OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
				return RedirectToLocal(returnUrl);
			}
			else
			{
				// User is new, ask for their desired membership name
				string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
				var oAuthClientData = OAuthWebSecurity.GetOAuthClientData(result.Provider);
				ViewBag.ProviderDisplayName = oAuthClientData.DisplayName;
				ViewBag.ReturnUrl = returnUrl;
				return View("Confirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
			}
		}

		//
		// POST: /Account/ExternalLogin/Confirmation

		[HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
		public ActionResult Confirmation(RegisterExternalLoginModel model, string returnUrl)
		{
			string provider = null;
			string providerUserId = null;

			if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
			{
				return RedirectToAction("Manage");
			}

			if (ModelState.IsValid)
			{
				var userName = provider + "_" + providerUserId;
				var userProfile = this.usersService.GetUserProfile(userName);
				if (userProfile == null)
				{
					userProfile = new User { Name = provider + "_" + providerUserId, Email = model.UserName };
					this.usersService.Save(userProfile);
				}

				OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, userProfile.Name);

				OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

				return RedirectToLocal(returnUrl);
			}

			ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
			ViewBag.ReturnUrl = returnUrl;
			return View(model);
		}

		//
		// GET: /Account/ExternalLogin/Failure

		[AllowAnonymous]
		public ActionResult Failure()
		{
			return View();
		}

		internal class ExternalLoginResult : ActionResult
		{
			public ExternalLoginResult(string provider, string returnUrl)
			{
				Provider = provider;
				ReturnUrl = returnUrl;
			}

			public string Provider { get; private set; }
			public string ReturnUrl { get; private set; }

			public override void ExecuteResult(ControllerContext context)
			{
				OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
			}
		}

		private ActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction("Index", "Home", new { area = "" });
			}
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using BootstrapMvcSample.Controllers;

using SportTracker.WebUI.Filters;
using SportTracker.WebUI.Infrastructure.Abstract;
using SportTracker.WebUI.Models;

using WebMatrix.WebData;

namespace SportTracker.WebUI.Controllers
{
	
	[InitializeSimpleMembership]
	public class AccountController :  BootstrapBaseController
	{
		private IAuthProvider authProvider;

		public AccountController(IAuthProvider auth)
		{
			authProvider = auth;
		}

		public ViewResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginViewModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				if (authProvider.Authenticate(model.UserName, model.Password, model.RememberMe))
				{
					return Redirect(returnUrl ?? Url.Action("Index", "Home"));
				}
				else
				{
					ModelState.AddModelError("", "Incorrect username or password");
					return View();
				}
			}
			else
			{
				return View();
			}
		}

		//
		// POST: /Account/LogOff

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff()
		{
			WebSecurity.Logout();

			return RedirectToAction("Index", "Home");
		}

		//
		// GET: /Account/Register

		[AllowAnonymous]
		public ActionResult Register()
		{
			return View();
		}

		//
		// POST: /Account/Register

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				// Attempt to register the user
				try
				{
					WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
					WebSecurity.Login(model.UserName, model.Password);
					return RedirectToAction("Index", "Home");
				}
				catch (MembershipCreateUserException e)
				{
					ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
				}
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}


		private static string ErrorCodeToString(MembershipCreateStatus createStatus)
		{
			// See http://go.microsoft.com/fwlink/?LinkID=177550 for
			// a full list of status codes.
			switch (createStatus)
			{
				case MembershipCreateStatus.DuplicateUserName:
					return "User name already exists. Please enter a different user name.";

				case MembershipCreateStatus.DuplicateEmail:
					return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

				case MembershipCreateStatus.InvalidPassword:
					return "The password provided is invalid. Please enter a valid password value.";

				case MembershipCreateStatus.InvalidEmail:
					return "The e-mail address provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidAnswer:
					return "The password retrieval answer provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidQuestion:
					return "The password retrieval question provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidUserName:
					return "The user name provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.ProviderError:
					return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				case MembershipCreateStatus.UserRejected:
					return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				default:
					return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
			}
		}


	}
}

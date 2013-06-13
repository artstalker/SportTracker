﻿using System.Web.Mvc;

using Microsoft.Web.WebPages.OAuth;

using SportTracker.WebUI.Areas.Account.Models;

using WebMatrix.WebData;

namespace SportTracker.WebUI.Areas.Account.Controllers
{
	public class LoginController : Controller
	{
		//
		// GET: /Account/Login/

		public ActionResult Index()
		{
			return View();
		}

		//
		// POST: /Account/Login

		[HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
		public ActionResult Index(LoginModel model, string returnUrl)
		{
			if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
			{
				return Url.IsLocalUrl(returnUrl) ? (ActionResult)Redirect(returnUrl) : RedirectToAction("Index", "Home", new { area = "" });
			}

			// If we got this far, something failed, redisplay form
			ModelState.AddModelError("", "The user name or password provided is incorrect.");
			return View(model);
		}

		[ChildActionOnly, AllowAnonymous]
		public ActionResult ExternalLoginsList(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return PartialView("_ExternalLoginsList", OAuthWebSecurity.RegisteredClientData);
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportTracker.WebUI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	public class UsersController : Controller
	{
		//
		// GET: /Admin/Users/

		public ActionResult Index()
		{
			return View();
		}

	}
}

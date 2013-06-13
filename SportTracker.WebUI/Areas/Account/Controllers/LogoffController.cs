using System.Web.Mvc;

using WebMatrix.WebData;

namespace SportTracker.WebUI.Areas.Account.Controllers
{
	public class LogoffController : Controller
	{
		//
		// POST: /Account/LogOff

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Index()
		{
			WebSecurity.Logout();

			return RedirectToAction("Index", "Home", new { area = "" });
		}

	}
}

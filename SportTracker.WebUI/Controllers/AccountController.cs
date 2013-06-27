using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportTracker.Domain.Abstract;

namespace SportTracker.WebUI.Controllers
{
    public class AccountController : Controller
    {

		  private readonly IUserRepository usersService;

		  public AccountController(IUserRepository usersService)
		 {
			 this.usersService = usersService;
		 }

        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

		  //
		  // GET: /Account/

		  public ActionResult Manage()
		  {
			  var userProfile = usersService.GetUserProfile(User.Identity.Name);
			  
			  return View(userProfile);
		  }

    }
}

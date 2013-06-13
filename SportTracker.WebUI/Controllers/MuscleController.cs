using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BootstrapMvcSample.Controllers;

using SportTracker.Domain.Abstract;

namespace SportTracker.WebUI.Controllers
{
	public class MuscleController : BootstrapBaseController
	{
		
		public MuscleController()
		{
			
		}

		public ViewResult List()
		{
			return View();

		}
	}
}

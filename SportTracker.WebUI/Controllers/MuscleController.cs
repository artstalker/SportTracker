﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportTracker.WebUI.Abstract;

namespace SportTracker.WebUI.Controllers
{
	public class MuscleController : Controller
	{
		private IMuscleRepository repository;
		public MuscleController(IMuscleRepository productRepository)
		{
			this.repository = productRepository;
		}

		public ViewResult List()
		{
			return View(repository.Muscles);

		}
	}
}

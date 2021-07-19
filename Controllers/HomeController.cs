using identity_2auth_mvc.Data;
using identity_2auth_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Controllers
{
	// Customized Controller for handling view not found
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index(string id) // NOTE: THIS LINE MODIFIED
		{
			return View(viewName: id); // NOTE: THIS LINE MODIFIED
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] // MUST NOT ALLOW CACHING
		public IActionResult Error()
		{
			var ehpf = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();
			if (ehpf.Error.Source == "Microsoft.AspNetCore.Mvc.ViewFeatures" && (ehpf.Error.HResult == -2146233079 || ehpf.Error.Message.Contains("was not found")))
				return View(new ErrorViewModel(404, ehpf.Path));
			return View(new ErrorViewModel(ehpf.Path) { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[Route("Home/Error/{id}")]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] // MUST NOT ALLOW CACHING
		public IActionResult Error(int id)
		{
			return View(new ErrorViewModel(id));
		}

		public IActionResult Privacy()
		{
			return View();
		}

	}
}

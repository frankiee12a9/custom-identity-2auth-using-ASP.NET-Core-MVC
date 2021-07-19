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
    public class ErrorController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [Route("404")]
        public IActionResult PageNotFound()
        {
            string originalPath = "unknown";
            if (HttpContext.Items.ContainsKey("originalPath"))
            {
                originalPath = HttpContext.Items["originalPath"] as string;
            }

            return View();
        }

    }
}
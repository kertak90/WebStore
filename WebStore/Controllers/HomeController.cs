using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return Content("12345");
            return View();
        }

        public IActionResult NotFound()
        {
            //return Content("12345");
            return View();
        }

    }
}
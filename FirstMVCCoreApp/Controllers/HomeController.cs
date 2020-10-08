using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstMVCCoreApp.Models;

namespace FirstMVCCoreApp.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("~/")]
      
        public IActionResult Index()
        {
            return View();
        }

        //[Route("about-us/{id}/test/{name}")]
        [Route("~/about-us/{name:alpha:minlength(5)}")]
        public IActionResult Privacy(string name)
        {
            return View();
        }
      //  [HttpGet("contact-us",Name ="contact",Order =1)]
        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

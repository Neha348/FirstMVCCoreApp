using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstMVCCoreApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using FirstMVCCoreApp.Repository;

namespace FirstMVCCoreApp.Controllers
{
    [Route("[controller]/[action]")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewBookAlertConfig _newBookAlertConfig;
        private readonly NewBookAlertConfig _thirdpartyBookConfig;
        private readonly IMessageRepository _messageRepository;

        public HomeController(IOptionsMonitor<NewBookAlertConfig> newBookAlertConfig, IMessageRepository messageRepository)
        {
            _newBookAlertConfig = newBookAlertConfig.Get("InternalBook");
            _messageRepository = messageRepository;
            _thirdpartyBookConfig = newBookAlertConfig.Get("ThirdpartyBook");
        }
     

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        [Route("~/")]
      
        public IActionResult Index()
        {
           bool isdisplay= _newBookAlertConfig.DisplayNewBookAlert;
            bool isdisplay2 = _thirdpartyBookConfig.DisplayNewBookAlert;
            //var value = _messageRepository.Getname();
           
            //var newbookalert = new NewBookAlertConfig();
            //configuration.Bind("NewBookAlert", newbookalert);
            //bool IsDisplay = newbookalert.DisplayNewBookAlert;
            //var newbook = configuration.GetSection("NewBookAlert");
            //var result2 = newbook.GetValue<bool>("DisplayNewBookAlert");
            //var bookname= newbook.GetValue<string>("Bookname");
            //var result = configuration["AppName"];
            //var Key1 = configuration["InfoObj:Key1"];
            //var Key2 = configuration["InfoObj:Key2"];
            //var Key3 = configuration["InfoObj:Key3:Key3Obj1"];
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

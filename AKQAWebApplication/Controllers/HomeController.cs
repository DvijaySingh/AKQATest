using AKQA.Contract;
using AKQA.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AKQAWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFormatNumber _formatNumber;
        private readonly ILog _log;

        public HomeController(IFormatNumber formatNumber,ILog log)
        {
            _formatNumber = formatNumber;
            _log = log;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}

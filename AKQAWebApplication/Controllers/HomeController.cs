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

        public JsonResult ConvertNumberToWord(Employee employee)
        {
            try
            {
                _log.Information($"Input Name {employee.Name} Input Number {employee.Salary}");
                employee.SalaryString = _formatNumber.ConvertNumberToWord(employee.Salary);
                _log.Information($"Word converstion of number is {employee.SalaryString}");
            }
            catch(Exception ex)
            {
                employee.SalaryString = "System error please try again!";
                _log.Error("Home controller - ConvertNumberToWord fails", ex);
            }
            return Json(employee);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AKQA.Contract;
using AKQA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AKQAWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatNumberAPIController : ControllerBase
    {
        private readonly IFormatNumber _formatNumber;
        private readonly ILog _log;

        public FormatNumberAPIController(IFormatNumber formatNumber, ILog log)
        {
            _formatNumber = formatNumber;
            _log = log;
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            try
            {
                _log.Information($"Input Name {employee.Name} Input Number {employee.Salary}");
                employee.SalaryString = _formatNumber.ConvertNumberToWord(employee.Salary);
                _log.Information($"Word converstion of number is {employee.SalaryString}");
            }
            catch (Exception ex)
            {
                employee.SalaryString = "System error please try again!";
                _log.Error("Home controller - ConvertNumberToWord fails", ex);
                return new BadRequestResult();
            }
            return Ok(employee);
        }
    }
}
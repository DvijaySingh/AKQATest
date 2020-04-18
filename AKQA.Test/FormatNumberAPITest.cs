using AKQA.Contract;
using AKQA.Models;
using AKQAWebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKQA.Test
{

    class FormatNumberAPITest
    {
        private readonly Mock<IFormatNumber> _formatNumber;
        private readonly Mock<ILog> _log;
        private readonly FormatNumberAPIController formatNumberAPIController;
        private string expectedString = "THREE THOUSAND DOLLARS";
        private Employee employee;
        public FormatNumberAPITest()
        {

            _formatNumber = new Mock<IFormatNumber>();
            _log = new Mock<ILog>();
            employee = new Employee
            {
                Name = "Durg Vijay Singh",
                Salary = 3000M
            };
            formatNumberAPIController = new FormatNumberAPIController(_formatNumber.Object, _log.Object);
        }
        [SetUp]
        public void Setup()
        {
            _formatNumber.Setup(s => s.ConvertNumberToWord(It.IsAny<decimal>())).Returns(expectedString);
        }

        [Test]
        public void When_EnterNameAndNumber()
        {
            var result = formatNumberAPIController.Post(employee) as OkObjectResult;
            Assert.AreEqual(3000M, employee.Salary);
            Assert.AreEqual(expectedString, employee.SalaryString);
            Assert.AreEqual("Durg Vijay Singh", employee.Name);
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]
        public void When_ConvertNumberToWord_GetException()
        {
            _formatNumber.Setup(s => s.ConvertNumberToWord(It.IsAny<decimal>())).Throws(new System.Exception());
            var result = formatNumberAPIController.Post(employee) as BadRequestResult;
            Assert.AreEqual("System error please try again!", employee.SalaryString);
            Assert.AreEqual(400, result.StatusCode);
        }
    }
}

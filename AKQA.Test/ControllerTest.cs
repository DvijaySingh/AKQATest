using AKQA.Contract;
using AKQA.Models;
using AKQAWebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace AKQA.Test
{
    public class ControllerTest
    {
        private readonly Mock<IFormatNumber> _formatNumber;
        private readonly Mock<ILog> _log;
        private readonly HomeController homeController;
        private string expectedString = "THREE THOUSAND DOLLARS";
        private Employee employee;
        public ControllerTest()
        {
            _formatNumber = new Mock<IFormatNumber>();
            _log = new Mock<ILog>();
            employee = new Employee
            {
                Name = "Durg Vijay Singh",
                Salary = 3000M
            };
            homeController = new HomeController(_formatNumber.Object, _log.Object);
        }
        [SetUp]
        public void Setup()
        {
            _formatNumber.Setup(s => s.ConvertNumberToWord(It.IsAny<decimal>())).Returns(expectedString);
        }

        [Test]
        public void When_Call_Index()
        {
           var result= homeController.Index() as ViewResult;
            Assert.IsNull(result.ViewName);
        }
        
    }
}
using AKQA.Business;
using AKQA.Contract;
using Moq;
using NUnit.Framework;

namespace AKQA.Test.BusinessLayer
{
    public class FormatNumberTest
    {
        private readonly Mock<ILog> _log;
        private readonly FormatNumber formatNumber;
        public FormatNumberTest()
        {
            _log = new Mock<ILog>();
            formatNumber = new FormatNumber(_log.Object);

        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_Number_Is_Without_DecimalPoints()
        {
            var outputString = formatNumber.ConvertNumberToWord(2010M);
            Assert.AreEqual("TWO THOUSAND AND TEN DOLLARS", outputString);
        }
        [Test]
        public void When_Number_Is_Negative()
        {
            var outputString = formatNumber.ConvertNumberToWord(-2010M);
            Assert.AreEqual("MINUS TWO THOUSAND AND TEN DOLLARS", outputString);
        }
        [Test]
        public void When_Number_Have_One_DecimalDigit()
        {
            var outputString = formatNumber.ConvertNumberToWord(2010.1M);
            Assert.AreEqual("TWO THOUSAND AND TEN DOLLARS AND TEN CENTS", outputString);
        }

        [Test]
        public void When_Number_Have_TWO_DecimalDigit()
        {
            var outputString = formatNumber.ConvertNumberToWord(2010.12M);
            Assert.AreEqual("TWO THOUSAND AND TEN DOLLARS AND TWELVE CENTS", outputString);
        }
        [Test]
        public void When_Number_Have_TWO_DecimalDigit_Having_Firstdigit_Zero()
        {
            var outputString = formatNumber.ConvertNumberToWord(2010.02M);
            Assert.AreEqual("TWO THOUSAND AND TEN DOLLARS AND TWO CENTS", outputString);
        }
        [Test]
        public void When_Number_Have_TWO_DecimalDigit_Having_Seconddigit_Zero()
        {
            var outputString = formatNumber.ConvertNumberToWord(201000.20M);
            Assert.AreEqual("TWO LAKHS  AND ONE THOUSAND AND  DOLLARS AND TWENTY CENTS", outputString);
        }
        [Test]
        public void When_Number_Have_TWO_DecimalDigit_BothZero()
        {
            var outputString = formatNumber.ConvertNumberToWord(201000.00M);
            Assert.AreEqual("TWO LAKHS  AND ONE THOUSAND AND  DOLLARS", outputString);
        }
        [Test]
        public void When_Number_StartWith_Zero()
        {
            var outputString = formatNumber.ConvertNumberToWord(00201000.00M);
            Assert.AreEqual("TWO LAKHS  AND ONE THOUSAND AND  DOLLARS", outputString);
        }
        [Test]
        public void When_Number_is_Zero()
        {
            var outputString = formatNumber.ConvertNumberToWord(0M);
            Assert.AreEqual("ZERO DOLLARS", outputString);
        }
        [Test]
        public void When_Number_Having_Only_DecimalDigit()
        {
            var outputString = formatNumber.ConvertNumberToWord(0.10M);
            Assert.AreEqual("ZERO DOLLARS AND TEN CENTS", outputString);
        }
    }
}

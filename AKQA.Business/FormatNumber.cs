using AKQA.Contract;
using System;
using System.Text;

namespace AKQA.Business
{
    public class FormatNumber : IFormatNumber
    {
        private ILog _log;
        public FormatNumber(ILog log)
        {
            _log = log;
        }
        /// <summary>
        /// Convert any decimal number to words
        /// </summary>
        /// <param name="number">deimal number</param>
        /// <returns>string</returns>
        public string ConvertNumberToWord(decimal number)
        {
            _log.Information($"Entered Number {number}");
            StringBuilder words = new StringBuilder();
            var numberArray = number.ToString().Split('.');
            var numberPart = Convert.ToInt32(numberArray[0]);
            words.Append(GetNumberString(numberPart) + " DOLLARS");
            _log.Information($"Number part convertion in word is - {words.ToString()}");
            if (numberArray.Length > 1 && Convert.ToInt32(numberArray[1]) > 0)
            {
                if (numberArray[1].Length == 1)
                {
                    numberArray[1] = numberArray[1] + "0";
                }
                words.Append(" AND " + GetDecimalString(Convert.ToInt32(numberArray[1])));
            }
            _log.Information($"Final convertion in word is - {words.ToString()}");

            return words.ToString().Trim();
        }
        /// <summary>
        /// Get last two digit string from number
        /// </summary>
        /// <param name="lastTwodigits"></param>
        /// <returns></returns>
        private string GetLastTwoDigitString(int lastTwodigits)
        {
            StringBuilder sb = new StringBuilder();
            var unitsWords = new[]
            {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };
            var tensWords = new[]
            {
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };
            if (lastTwodigits > 0)
            {

                if (lastTwodigits < 20) sb.Append(unitsWords[lastTwodigits]);
                else
                {
                    sb.Append(tensWords[lastTwodigits / 10]);
                    if ((lastTwodigits % 10) > 0)
                    {
                        sb.Append(" " + unitsWords[lastTwodigits % 10]);
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Get numeric part number string
        /// </summary>
        /// <param name="numberPart">number</param>
        /// <returns>numberString</returns>
        private string GetNumberString(int numberPart)
        {

            if (numberPart == 0) return "ZERO";
            if (numberPart < 0) return "MINUS " + GetNumberString((numberPart * -1));
            StringBuilder words = new StringBuilder();
            if ((numberPart / 100000) > 0)
            {
                words.Append(GetNumberString(numberPart / 100000) + " LAKHS  AND ");
                numberPart %= 100000;
            }
            if ((numberPart / 1000) > 0)
            {
                words.Append(GetNumberString(numberPart / 1000) + " THOUSAND AND ");
                numberPart %= 1000;
            }
            if ((numberPart / 100) > 0)
            {
                words.Append(GetNumberString(numberPart / 100) + " HUNDRED  AND ");
                numberPart %= 100;
            }
            if (numberPart > 0)
            {
                words.Append(GetLastTwoDigitString(numberPart));
            }

            return words.ToString();
        }
        /// <summary>
        /// Get decimal numbers string
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string GetDecimalString(int number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetLastTwoDigitString(Convert.ToInt32(number)));
            sb.Append(" CENTS");

            return sb.ToString();
        }
    }
}

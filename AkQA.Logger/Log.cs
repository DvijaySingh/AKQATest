using AKQA.Contract;
using NLog;
using System;

namespace AkQA.Logger
{

    public class Log:ILog
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public Log()
        {

        }

        public void Error(string message, Exception exception)
        {
            logger.Error(exception, message);
        }

        public void Information(string message)
        {
            logger.Info(message);
        }
    }
}

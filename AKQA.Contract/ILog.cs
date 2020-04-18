using System;

namespace AKQA.Contract
{
    public interface ILog
    {
        void Information(string message);
        void Error(string message, Exception exception);
    }
}

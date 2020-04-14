using System;

namespace dependency_injection_revised
{
    public interface ILogger
    {
        void LogMessage(string msg);
    }

    public class FileLogger : ILogger
    {
        public void LogMessage(string msg) => throw new NotImplementedException();
    }

    public class DbLogger : ILogger
    {
        public void LogMessage(string msg) => throw new NotImplementedException();
    }

    public class ExceptionLogger
    {
        private ILogger _logger;

        public ExceptionLogger(ILogger exceptionLogger)
        {
            _logger = exceptionLogger;
        }

        public void LogException(Exception ex)
        {
            var msg = ObtainExceptionMessage(ex);
            _logger.LogMessage(msg);
        }

        private static string ObtainExceptionMessage(Exception ex) => ex.Message;
    }
}
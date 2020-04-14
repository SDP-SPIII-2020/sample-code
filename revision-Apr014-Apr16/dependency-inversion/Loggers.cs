using System;

namespace dependency_inversion
{
    // Stage One - client requests msgs stored in a File
    // Logs exception information into a file.
    public class FileLogger
    {
        public void LogMessage(string msg) => throw new NotImplementedException();
    }

    // Stage Two - client requests msgs stored in a database
    public class DbLogger
    {
        public void LogMessage(string msg) => throw new NotImplementedException();
    }

    public class ExceptionLogger
    {
        public void LogIntoFile(Exception ex)
        {
            var objFileLogger = new FileLogger();
            objFileLogger.LogMessage(ObtainExceptionMessage(ex));
        }

        public void LogIntoDatabase(Exception ex)
        {
            var objDbLogger = new DbLogger();
            objDbLogger.LogMessage(ObtainExceptionMessage(ex));
        }

        private static string ObtainExceptionMessage(Exception ex) => ex.Message;
    }
}
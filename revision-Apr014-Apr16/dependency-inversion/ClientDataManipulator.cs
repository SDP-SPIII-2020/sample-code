using System;
using System.IO;

namespace dependency_inversion
{
    public class ClientDataManipulator
    {
        public void ExportDataFromFile()
        {
            try
            {
                // code to extract the data from a file and copy it somewhere.
                // throws an exception if inconsistent or invalid data.
            }
            catch (IOException ex)
            {
                new ExceptionLogger().LogIntoDatabase(ex);
            }
            catch (Exception ex)
            {
                new ExceptionLogger().LogIntoFile(ex);
            }
        }
    }
}
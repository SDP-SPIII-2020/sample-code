namespace BankAccount
{
    /// <summary>
    /// currency conversion not available for this account
    /// </summary>
    public class NoConversionException : System.Exception
    {
        public NoConversionException(string msg) : base(msg)
        {
        }
    }
}
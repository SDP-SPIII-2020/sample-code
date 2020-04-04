namespace BankAccount
{
    /// <summary>
    /// currency conversion not available for this account
    /// </summary>
    public class NoConversion : System.Exception
    {
        public NoConversion(string msg) : base(msg)
        {
        }
    }
}
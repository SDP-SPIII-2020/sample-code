using System;

namespace BankAccount
{
    /// <summary>
    /// define an exception, triggered by the balance being too low
    /// </summary>
    public class InsufficientBalance : Exception
    {
        public InsufficientBalance(string msg) : base(msg)
        {
        }
    }
}
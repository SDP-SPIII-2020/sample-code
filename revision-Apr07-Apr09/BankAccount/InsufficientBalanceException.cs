using System;

namespace BankAccount
{
    /// <summary>
    /// define an exception, triggered by the balance being too low
    /// </summary>
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string msg) : base(msg)
        {
        }
    }
}
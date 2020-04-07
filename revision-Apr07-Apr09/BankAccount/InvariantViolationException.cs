using System;

namespace BankAccount
{
    /// <summary>
    /// define an exception, triggered by an invariant violation
    /// </summary>
    public class InvariantViolationException : Exception
    {
        public InvariantViolationException(string msg) : base(msg)
        {
        }
    }
}
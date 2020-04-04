using System;

namespace BankAccount
{
    /// <summary>
    /// define an exception, triggered by an invariant violation
    /// </summary>
    public class InvariantViolation : Exception
    {
        public InvariantViolation(string msg) : base(msg)
        {
        }
    }
}
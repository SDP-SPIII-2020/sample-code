using System;

namespace ClassesQuickstart
{
    public interface IBankAccount
    {
        string Number { get; }
        string Owner { get; }
        decimal Balance { get; }
        void MakeDeposit(decimal amount, DateTime date, string note);
        void MakeWithdrawal(decimal amount, DateTime date, string note);
        string GetAccountHistory();
    }
}
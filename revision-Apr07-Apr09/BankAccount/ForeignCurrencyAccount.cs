using System;
using System.Diagnostics.Contracts;

namespace BankAccount
{
    internal class ForeignCurrencyAccount : ProperBankAccount
    {
        // currency
        private string Currency { get; }

        // exchange rate
        private double Rate { get; }

        public ForeignCurrencyAccount(string name, string cur, double rate) : base(name)
        {
            Currency = cur;
            Rate = rate;
        }

        public override double ConvertToGbp() => (double) Balance * Rate;

        public override void ShowAccount()
        {
            base.ShowAccount();
            Console.WriteLine(
                $"\tthe currency on this account is {Currency} with an exchange rate {Currency}->GBP of 1:{Rate}");
            Console.WriteLine($"\tthe balance in GBP is {ConvertToGbp()}");
        }

        // Class invariants (using Code Contracts): 
        // invariant: this.balance >= - this.overdraft   
        [ContractInvariantMethod]
        public new void ObjectInvariant()
        {
            Contract.Invariant(this.Balance >= -this.Overdraft);
        }
    }
}
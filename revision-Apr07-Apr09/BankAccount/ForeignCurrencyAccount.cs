using System;
using System.Diagnostics.Contracts;

namespace BankAccount
{
    class ForeignCurrencyAccount : ProperBankAccount
    {
        // currency
        public string currency { get; set; }

        // exchange rate
        public double rate { get; set; }

        public ForeignCurrencyAccount(string name, string cur, double rate) : base(name)
        {
            this.currency = cur;
            this.rate = rate;
        }

        public override double ConvertToGbp()
        {
            return (double) this.Balance * this.rate;
        }

        public override void ShowAccount()
        {
            base.ShowAccount();
            Console.WriteLine("\tthe currency on this account is {0} with an exchange rate {0}->GBP of 1:{1}",
                this.currency, this.rate);
            Console.WriteLine("\tthe balance in GBP is {0}", ConvertToGbp());
        }

        // Class invariants (using Code Contracts): 
        // invariant: this.balance >= - this.overdraft   
        [ContractInvariantMethod]
        public void ObjectInvariant()
        {
            Contract.Invariant(this.Balance >= -this.Overdraft);
        }
    }
}
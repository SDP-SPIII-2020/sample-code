using System;
using System.Diagnostics.Contracts;

namespace BankAccount
{
    class ProperBankAccount : BankAccount
    {
        // overdraft field, with default get and set properties
        public decimal Overdraft { get; set; }

        // constructor (overloaded)
        public ProperBankAccount(string name) : base(name)
        {
            // nothing; use set property on overdraft
        }

        // constructor (overloaded): fixed account number
        public ProperBankAccount(ulong no, string name) : base(no, name)
        {
            // nothing; use set property on overdraft
        }

        // Deposit is inherited from BankAccount

        // NB: override Withdraw to account for overdraft
        public override void Withdraw(decimal x)
        {
            Contract.Requires(x >= 0);
            if (this.Balance + this.Overdraft >= x)
            {
                this.Balance -= x;
            }
            else
            {
                throw new InsufficientBalance(String.Format("Balance (including overdraft of {0}) too low: {1}",
                    this.Overdraft, this.Balance));
            }

            Contract.Ensures(this.Balance + this.Overdraft >= 0);
        }

        // GetBalance and ShowBalance are inherited

        // override ShowAccount
        public override void ShowAccount()
        {
            base.ShowAccount();
            Console.WriteLine("\twith an overdraft of {0}", this.Overdraft);
        }

        public override double ConvertToGbp()
        {
            return (double) this.Balance;
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
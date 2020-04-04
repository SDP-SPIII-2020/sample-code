using System;
using System.Diagnostics.Contracts;

namespace BankAccount
{
    class BankAccount
    {
        // a static field, holding the latest account number
        protected static ulong latestAccountNo = 1000; // 29857243

        // fields; protected, to be visible in derived classes
        protected ulong accountNo;
        protected decimal balance;
        protected string name;

        // <summary>
        //  constructor (overloaded): auto assign account number
        // </summary>
        // <param name="name">Name of the account</param>
        public BankAccount(string name)
        {
            latestAccountNo++;
            this.accountNo = latestAccountNo;
            this.name = name;
            this.balance = 0M;
        }

        // <summary>
        //  constructor (overloaded): fixed account number
        // </summary>
        // <param name="no">Account number</param>
        // <param name="name">Name of the account</param>
        public BankAccount(ulong no, string name)
        {
            this.accountNo = no;
            this.name = name;
            this.balance = 0M;
        }

        // <summary>
        //    depositing money into the account
        // </summary>
        // <param name="x" type="decimal">amount to deposit</param>
        // <requires>x>=0</requires>
        public void Deposit(decimal x)
        {
            Contract.Requires(x >= 0);
            this.balance += x;
        }

        // <summary>
        //   withdrawing money from the account
        // </summary>
        // <param name="x" type="decimal">amount to withdraw from the account</param>
        // <requires>x>=0</requires>
        // <provides>this.balance>=0<provides>
        // NB: we want to override this for a ProperBankAccount, hence virtual
        public virtual void Withdraw(decimal x)
        {
            Contract.Requires(x >= 0);
            if (this.balance >= x)
            {
                this.balance -= x;
            }
            else
            {
                throw new InsufficientBalance(String.Format("Balance too low: {0}", this.balance));
            }

            Contract.Ensures(this.balance >= 0);
        }

        // read balance field
        public decimal GetBalance()
        {
            return this.balance;
        }

        // show balance field
        public void ShowBalance()
        {
            Console.WriteLine("Current Balance: " + this.balance.ToString());
        }

        // show details of the account
        public virtual void ShowAccount()
        {
            Console.WriteLine("Account Number: {0}\tAccount Name: {1}\tCurrent Balance: {2}",
                this.accountNo, this.name, this.balance.ToString());
        }

        public virtual double ConvertToGBP()
        {
            throw new NoConversion("Currency conversion not implemented for a (basic) BankAccount");
        }

        // Class invariant (using Code Contracts): 
        // invariant: this.balance >= 0
        [ContractInvariantMethod]
        public void ObjectInvariant()
        {
            Contract.Invariant(this.balance >= 0);
        }

        // -----------------------------------------------------------------------------
        public void RunTrans()
        {
            // works on BankAccount and ProperBankAccount
            this.ShowAccount();
            this.ShowBalance();
            Console.WriteLine("Depositing " + 600);
            this.Deposit(600);
            this.ShowBalance();
            Console.WriteLine("Withdrawing " + 400);
            try
            {
                this.Withdraw(400);
            }
            catch (InsufficientBalance e)
            {
                Console.WriteLine("InsufficientBalance {0} for withdrawl of {1}", this.GetBalance(), 400);
            }

            this.ShowBalance();
            Console.WriteLine("Withdrawing " + 400);
            try
            {
                this.Withdraw(400);
            }
            catch (InsufficientBalance e)
            {
                Console.WriteLine("InsufficientBalance {0} for withdrawl of {1}", this.GetBalance(), 400);
            }

            this.ShowBalance();
            this.ShowAccount();
        }
    }
}
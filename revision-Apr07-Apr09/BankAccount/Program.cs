// C# Revision: extended bank account
// Additionally uses:
// . refined access modifiers
// . hiding methods of the base-class
// . inheritance to add an overdraft facility
// . automatic properties to implement Overdraft
// . exception to handle insufficient balance
// . overloading (on constructors)
// . static fields (auto generate account number)
//
// For guidance on tags in documentation check:
//  http://msdn.microsoft.com/en-us/library/5ast78ax%28v=vs.90%29.aspx
// This version additionally uses Code Contracts for pre- and post-conditions.
// -----------------------------------------------------------------------------

using System;
using System.Diagnostics.Contracts;

namespace BankAccount
{
    // the basic account
    // -----------------------------------------------------------------------------

    // -----------------------------------------------------------------------------

    internal class ForeignCurrencyAccount : ProperBankAccount
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

// -----------------------------------------------------------------------------

    class Tester
    {
        // a class for running tests from the Main method
        class RunTester
        {
            // RunTransactions works on BankAccount and ProperBankAccount
            public void RunTransactions(BankAccount acct)
            {
                // if it has an overdraft facility, initialise its value
                ProperBankAccount pacct = acct as ProperBankAccount;
                if (pacct != null)
                {
                    pacct.Overdraft = 200M;
                }

                /* or:
              if (acct is ProperBankAccount) {
            ((ProperBankAccount)acct).overdraft = 200;
              }
              */
                acct.ShowAccount();
                acct.ShowBalance();
                // first, deposit something 
                decimal x = 600M;
                Console.WriteLine("Depositing " + x);
                acct.Deposit(x);
                acct.ShowBalance();
                // then, try to withdraw something 
                decimal y = 400M;
                Console.WriteLine("Withdrawing " + y);
                try
                {
                    acct.Withdraw(y);
                }
                catch (InsufficientBalance e)
                {
                    Console.WriteLine("InsufficientBalance {0} for withdrawl of {1}", acct.GetBalance(), y);
                }

                acct.ShowBalance();
                // then, try to withdraw the same amount again
                Console.WriteLine("Withdrawing " + y);
                try
                {
                    acct.Withdraw(y);
                }
                catch (InsufficientBalance e)
                {
                    Console.WriteLine("InsufficientBalance {0} for withdrawl of {1}", acct.GetBalance(), y);
                }

                acct.ShowBalance();
                acct.ShowAccount();
            }
        }

        public static void Main()
        {
            RunTester t = new RunTester();

            // create a basic account
            BankAccount mine = new BankAccount("MyAccount");
            // create a proper account
            ProperBankAccount mineOvdft = new ProperBankAccount("MyProperAccount");
            // create a proper account
            ForeignCurrencyAccount foreign = new ForeignCurrencyAccount("ProperBankAccount", "EUR", 0.80);

            // collect them in an array
            BankAccount[] accts = new BankAccount[3] {mine, mineOvdft, foreign};

            for (int i = 0; i < accts.Length; i++)
            {
                t.RunTransactions(accts[i]); // or: accts[i].RunTrans();
            }

            // compute the overall sum, always converting to GBP
            double sum = 0.0;
            for (int i = 0; i < accts.Length; i++)
            {
                try
                {
                    sum += accts[i].ConvertToGbp(); // or: accts[i].RunTrans();
                }
                catch (NoConversion e)
                {
                    Console.WriteLine("Ignoring {0}-th account in total balance: cannot convert to GBP", i);
                    accts[i].ShowAccount();
                }
            }

            System.Console.WriteLine("Total balance (in GBP): {0}", sum);
            // Main0();
        }

        public static void Main0()
        {
            // alternative version of the above
            // create a basic account
            BankAccount mine2 = new BankAccount("My2ndAccount");
            // run transactions
            mine2.RunTrans();

            // create a proper account
            ProperBankAccount mine2Ovdft = new ProperBankAccount("My2ndProperAccount");
            mine2Ovdft.Overdraft = 250;
            // run transactions
            mine2Ovdft.RunTrans();

            // create a proper account
            ForeignCurrencyAccount foreign = new ForeignCurrencyAccount("ProperBankAccount", "EUR", 0.80);
            foreign.Overdraft = 50;
            // run transactions
            foreign.RunTrans();

            try
            {
                Console.WriteLine("Trying to withdraw 300");
                mine2Ovdft.Withdraw(300);
            }
            catch (InsufficientBalance e)
            {
                Console.WriteLine("InsufficientBalance {0} for withdrawl of {1}", mine2Ovdft.GetBalance(), 300);
            }

            Console.WriteLine("Balance of mineOvdft {0}", mine2Ovdft.GetBalance());
            mine2Ovdft.ShowAccount();
        }
    }
}
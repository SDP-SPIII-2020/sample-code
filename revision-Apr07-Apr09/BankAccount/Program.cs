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

namespace BankAccount
{
    internal static class Program
    {
        // a class for running tests from the Main method
        private class RunTester
        {
            // RunTransactions works on BankAccount and ProperBankAccount
            public void RunTransactions(BankAccount acct)
            {
                // if it has an overdraft facility, initialise its value
                if (acct is ProperBankAccount pacct)
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
                var x = 600M;
                Console.WriteLine("Depositing " + x);
                acct.Deposit(x);
                acct.ShowBalance();

                // then, try to withdraw something 
                var y = 400M;
                Console.WriteLine("Withdrawing " + y);
                try
                {
                    acct.Withdraw(y);
                }
                catch (InsufficientBalanceException e)
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
                catch (InsufficientBalanceException e)
                {
                    Console.WriteLine("InsufficientBalance {0} for withdrawl of {1}", acct.GetBalance(), y);
                }

                acct.ShowBalance();
                acct.ShowAccount();
            }
        }

        public static void Main()
        {
            var t = new RunTester();

            // create a basic account
            var mine = new BankAccount("MyAccount");
            // create a proper account
            var mineOvdft = new ProperBankAccount("MyProperAccount");
            // create a proper account
            var foreign = new ForeignCurrencyAccount("ProperBankAccount", "EUR", 0.80);

            // collect them in an array
            var accts = new BankAccount[3] {mine, mineOvdft, foreign};

            foreach (var t1 in accts)
            {
                t.RunTransactions(t1); // or: accts[i].RunTrans();
            }

            // compute the overall sum, always converting to GBP
            var sum = 0.0;
            for (var i = 0; i < accts.Length; i++)
            {
                try
                {
                    sum += accts[i].ConvertToGbp(); // or: accts[i].RunTrans();
                }
                catch (NoConversionException e)
                {
                    Console.WriteLine("Ignoring {0}-th account in total balance: cannot convert to GBP", i);
                    accts[i].ShowAccount();
                }
            }

            Console.WriteLine("Total balance (in GBP): {0}", sum);
            Main0();
        }

        private static void Main0()
        {
            // alternative version of the above
            // create a basic account
            var mine2 = new BankAccount("My2ndAccount");
            // run transactions
            mine2.RunTrans();

            // create a proper account
            var mine2Ovdft = new ProperBankAccount("My2ndProperAccount") {Overdraft = 250};
            // run transactions
            mine2Ovdft.RunTrans();

            // create a proper account
            var foreign = new ForeignCurrencyAccount("ProperBankAccount", "EUR", 0.80) {Overdraft = 50};
            // run transactions
            foreign.RunTrans();

            try
            {
                Console.WriteLine("Trying to withdraw 300");
                mine2Ovdft.Withdraw(300);
            }
            catch (InsufficientBalanceException e)
            {
                Console.WriteLine("InsufficientBalance {0} for withdrawl of {1}", mine2Ovdft.GetBalance(), 300);
            }

            Console.WriteLine("Balance of mineOvdft {0}", mine2Ovdft.GetBalance());
            mine2Ovdft.ShowAccount();
        }
    }
}
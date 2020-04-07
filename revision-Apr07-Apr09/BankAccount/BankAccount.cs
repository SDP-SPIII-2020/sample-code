using System;
using System.Diagnostics.Contracts;

namespace BankAccount
{
    internal class BankAccount
    {
        // a static field, holding the latest account number
        private static ulong _latestAccountNo = 1000; // 29857243

        // fields; protected, to be visible in derived classes
        private readonly ulong _accountNo;
        protected decimal Balance;
        private readonly string _name;

        /// <summary>
        ///  constructor (overloaded): auto assign account number
        /// </summary>
        /// <param name="name">Name of the account</param>
        public BankAccount(string name) : this(++_latestAccountNo, name)
        {
        }

        /// <summary>
        ///  constructor (overloaded): fixed account number
        /// </summary>
        /// <param name="no">Account number</param>
        /// <param name="name">Name of the account</param>
        public BankAccount(ulong no, string name)
        {
            _accountNo = no;
            _name = name;
            Balance = 0M;
        }

        /// <summary>
        ///    depositing money into the account
        /// </summary>
        /// <param name="x" type="decimal">amount to deposit</param>
        /// <requires>x>=0</requires>
        public void Deposit(decimal x)
        {
            Contract.Requires(x >= 0);
            Balance += x;
        }

        /// <summary>
        ///   withdrawing money from the account
        /// </summary>
        /// <param name="x" type="decimal">amount to withdraw from the account</param>
        /// <requires>x>=0</requires>
        /// <provides>this.balance>=0</provides>
        /// NB: we want to override this for a ProperBankAccount, hence virtual
        public virtual void Withdraw(decimal x)
        {
            Contract.Requires(x >= 0);
            if (Balance >= x)
            {
                Balance -= x;
            }
            else
            {
                throw new InsufficientBalanceException($"Balance too low: {Balance}");
            }

            Contract.Ensures(this.Balance >= 0);
        }

        // read balance field
        public decimal GetBalance() => Balance;

        // show balance field
        public void ShowBalance() => Console.WriteLine($"Current Balance: {Balance}");

        // show details of the account
        public virtual void ShowAccount() =>
            Console.WriteLine($"Account Number: {_accountNo}\tAccount Name: {_name}\tCurrent Balance: {Balance}");

        public virtual double ConvertToGbp() =>
            throw new NoConversionException("Currency conversion not implemented for a (basic) BankAccount");

        // Class invariant (using Code Contracts): invariant: this.balance >= 0
        [ContractInvariantMethod]
        public void ObjectInvariant() => Contract.Invariant(this.Balance >= 0);

        // -----------------------------------------------------------------------------
        public void RunTrans()
        {
            // works on BankAccount and ProperBankAccount
            ShowAccount();
            ShowBalance();
            
            Console.WriteLine("Depositing " + 600); 
            Deposit(600);
            
            ShowBalance();
            Console.WriteLine("Withdrawing " + 400);
            
            try
            {
                Withdraw(400);
            }
            catch (InsufficientBalanceException e)
            {
                Console.WriteLine($"InsufficientBalance {GetBalance()} for withdrawal of {400}");
            }

            ShowBalance();
            
            Console.WriteLine("Withdrawing " + 400);
            try
            {
                Withdraw(400);
            }
            catch (InsufficientBalanceException e)
            {
                Console.WriteLine($"InsufficientBalance {GetBalance()} for withdrawal of {400}");
            }

            ShowBalance();
            ShowAccount();
        }
    }
}
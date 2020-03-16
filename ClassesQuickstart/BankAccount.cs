using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace ClassesQuickstart
{
    public class BankAccount : IBankAccount
    {
        public string Number { get; }
        public string Owner { get; }

        #region BalanceComputation

        public decimal Balance
        {
            get { return _allTransactions.Sum(item => item.Amount); }
        }

        #endregion

        private static int _accountNumberSeed = 1234567890;

        #region Constructor

        public BankAccount(string name, decimal initialBalance)
        {
            this.Number = _accountNumberSeed.ToString();
            _accountNumberSeed++;

            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        #endregion

        #region TransactionDeclaration

        private readonly List<Transaction> _allTransactions = new List<Transaction>();

        #endregion

        #region DepositAndWithdrawal

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }

            var deposit = new Transaction(amount, date, note);
            _allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            var withdrawal = new Transaction(-amount, date, note);
            _allTransactions.Add(withdrawal);
        }

        #endregion

        #region History

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

        #endregion
    }
}
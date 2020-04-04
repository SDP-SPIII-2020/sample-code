// Exercise 4a from Lecture 4: bank account
// see also extension of this example in the C# revision lecture

using System;
using System.Diagnostics.Contracts;

class BankAccount {
  private ulong accountNo;
  private long balance;
  private string name;

  public void Deposit(long x) {
    Contract.Requires( x >= 0 );
    this.balance += x;
  }

  public void Withdraw(long x) {
    Contract.Requires( x >= 0 );
    if (this.balance > x) { 
      this.balance -= x;
    } else {
      // could use an exception here
      Console.WriteLine("Current balance {0} is too low for withdrawing {1}", this.balance, x);
    }
  }

  public long GetBalance() { return this.balance; }

  public BankAccount(ulong no, string name) {
    this.accountNo = no;
    this.name = name;
    this.balance = 0;
  }

  public void ShowBalance() {
    Console.WriteLine("Current Balance: " + this.balance.ToString());
  }

  public void ShowAccount() {
    Console.WriteLine("Account Number: {0}\tAccount Name: {1}\tCurrent Balance: {2}", 
		      this.accountNo, this.name, this.balance.ToString());
  }

  // Class invariant (using Code Contracts): 
  // invariant: this.balance >= 0
  [ContractInvariantMethod]
  public void ObjectInvariant () {
    Contract.Invariant ( this.balance >= 0 );
  }
}

class Tester {
  public static void Main(){
    BankAccount mine = new BankAccount(29857243, "MyAccount");

    mine.ShowAccount();
    mine.ShowBalance();
    Console.WriteLine("Depositing " + 6);
    mine.Deposit(6);
    mine.ShowBalance();
    Console.WriteLine("Withdrawing " + 4);
    mine.Withdraw(4);
    mine.ShowBalance();
    Console.WriteLine("Withdrawing " + 4);
    mine.Withdraw(4);
    mine.ShowBalance();
    mine.ShowAccount();
  }
}
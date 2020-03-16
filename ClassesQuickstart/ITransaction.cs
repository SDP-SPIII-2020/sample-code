using System;

namespace ClassesQuickstart
{
    public interface ITransaction
    {
        decimal Amount { get; }
        DateTime Date { get; }
        string Notes { get; }
    }
}
namespace FunctionalProgrammingRedux
{
    public static class ImmutableTypes
    {
    }

    public class Money
    {
        public decimal Value { get; } // getter-only auto-property
        public Money(decimal value) => Value = value;
        public static Money Add(Money money, decimal value) => new Money(money.Value + value);
    }
}
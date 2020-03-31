using System;

namespace worksheet_ten_data_structures
{
    public class Holder<TV, T>
    {
        public TV Value { get; }
        public Func<object, T> Func { get; }

        public Holder(TV value, Func<object, T> func)
        {
            Value = value;
            Func = func;
        }
    }

    public static class Holder
    {
        public static Holder<V, T> Of<V, T>(V value)
            => new Holder<V, T>(value, x => (T) x);

        public static Holder<V, R> Map<V, T, R>(this Holder<V, T> @this, Func<T, R> func)
            => new Holder<V, R>(@this.Value, x => func(@this.Func(x)));
    }
}
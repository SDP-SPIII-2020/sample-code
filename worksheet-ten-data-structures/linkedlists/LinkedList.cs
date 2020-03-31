using System;
using System.Collections.Generic;
using System.Linq;
using Unit = System.ValueTuple;

namespace linkedlists
{
    // List<T> = Empty | Otherwise(T, List<T>)

    public sealed class List<T>
    {
        readonly bool _isEmpty;
        readonly T _head;
        readonly List<T> _tail;

        // the empty list
        internal List()
        {
            _isEmpty = true;
        }

        // the non empty list
        internal List(T head, List<T> tail)
        {
            this._head = head;
            this._tail = tail;
        }

        public TR Match<TR>(Func<TR> empty, Func<T, List<T>, TR> cons) => _isEmpty ? empty() : cons(_head, _tail);

        // for convenience
        public T Head => Match(
            () => throw new IndexOutOfRangeException(),
            (head, _) => head);

        public List<T> Tail => Match(
            () => throw new IndexOutOfRangeException(),
            (_, tail) => tail);

        // not really required, but hey...
        public T this[int index] => Match(
            () => throw new IndexOutOfRangeException(),
            (head, tail) => index == 0 ? head : tail[index - 1]);

        private IEnumerable<T> AsEnumerable()
        {
            if (_isEmpty) yield break;
            yield return _head;
            foreach (T t in _tail.AsEnumerable()) yield return t;
        }

        public override string ToString() => Match(
            () => "{ }",
            (_, __) => $"{{ {string.Join(", ", AsEnumerable().Map(v => v.ToString()))} }}");
    }

    public static class LinkedList
    {
        // factory functions
        private static List<T> List<T>(T h, List<T> t) => new List<T>(h, t);

        private static List<T> List<T>(params T[] items)
            => items.Reverse().Aggregate(new List<T>(), (tail, head) => List(head, tail));

        public static int Length<T>(this List<T> @this) => @this.Match(
            () => 0,
            (t, ts) => 1 + ts.Length());

        public static List<T> Add<T>(this List<T> @this, T value) => List(value, @this);

        public static List<T> Append<T>(this List<T> @this, T value)
            => @this.Match(
                () => List(value, List<T>()),
                (head, tail) => List(head, tail.Append(value)));

        private static List<R> Map<T, R>(this List<T> @this, Func<T, R> f)
            => @this.Match(
                () => List<R>(),
                (head, tail) => List(f(head), tail.Map(f)));

        public static Unit ForEach<T>(this List<T> @this, Action<T> action)
        {
            @this.Map(action.ToFunc());
            return Unit.Create();
        }

        public static List<R> Bind<T, R>(this List<T> @this, Func<T, List<R>> f) => @this.Map(f).Join();

        private static List<T> Join<T>(this List<List<T>> @this) => @this.Match(
            () => List<T>(),
            (xs, xss) => Concat(xs, Join(xss)));

        public static Acc Aggregate<T, Acc>(this List<T> @this, Acc acc, Func<Acc, T, Acc> f)
            => @this.Match(
                () => acc,
                (head, tail) => Aggregate(tail, f(acc, head), f));

        private static List<T> Concat<T>(List<T> l, List<T> r) => l.Match(
            () => r,
            (h, t) => List(h, Concat(t, r)));

        public static List<R> Run<T, R>(this Holder<List<T>, R> @this) => @this.Value.Map(t => @this.Func(t));
    }
}
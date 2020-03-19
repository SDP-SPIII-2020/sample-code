using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Parallel06
{
    internal class Pipeline<T> where T : IComparable
    {
        public delegate T IncDelegate(T x);

        private static void MkSequence(ICollection<T> seq, T m, T n, IncDelegate inc)
        {
            if (m.CompareTo(n) > 0)
            {
                // m>n
                return;
            }

            var m1 = inc(m);
            seq.Add(m);
            MkSequence(seq, m1, n, inc);
        }

        public delegate T ProducerDelegate(T x, T y);

        public static void Producer(BlockingCollection<T> output,
            T from, T to, IncDelegate inc
            /* int seed */)
        {
            Console.WriteLine("Producer running ... ");
            var items = new List<T>();
            MkSequence(items, from, to, inc);
            try
            {
                foreach (T item in items)
                {
                    output.Add(item);
                }
            }
            finally
            {
                output.CompleteAdding();
            }
        }

        public delegate T ConsumerDelegate(T x);

        public static void Consumer(BlockingCollection<T> input,
            ConsumerDelegate worker,
            BlockingCollection<T> output)
        {
            System.Console.WriteLine("Consumer running ... ");
            try
            {
                foreach (var item in input.GetConsumingEnumerable())
                {
                    var result = worker(item);
                    output.Add(result);
                }
            }
            finally
            {
                output.CompleteAdding();
            }
        }

        public static string LastConsumer(BlockingCollection<T> input, string str) =>
            input.GetConsumingEnumerable()
                .Aggregate(str, (current, item) => current + (" " + item.ToString()));
    }
}
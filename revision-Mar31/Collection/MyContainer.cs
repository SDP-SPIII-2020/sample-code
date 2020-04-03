using System;
using System.Threading.Tasks;

namespace Collection
{
    // a collection, generic over element type T
    // split into several files to decompose the functionality
    public partial class MyContainer<T> : ICloneable where T : IComparable<T>
    {
        public const int MaxItems = 16 * 256; // hard-wired upper bound

        private readonly T[] _items; // contents

        // constructor
        public MyContainer(params T[] inits)
        {
            // params allows a list of arguments rather than array
            _items = new T[MaxItems]; // could use inits.CopyTo(this.items, 0) here
            foreach (var t in inits) _items[Count++] = t;
        }

        public object Clone() => this.MemberwiseClone();

        public delegate int CompareDelegate(T t1, T t2);

        // -------------------------------------------------------
        // specialised methods

        public void Print()
        {
            // make use of IEnumerable implementation
            using var iter = GetEnumerator();
            Console.Write("Container contains: [");
            /* get ','s right */
            if (iter.MoveNext()) Console.Write(iter.Current);

            while (iter.MoveNext()) Console.Write($",{iter.Current}");

            Console.WriteLine("]");
        }

        // swap i-th and j-th element of the array
        private void Swap(int i, int j)
        {
            if (i == j) return;

            var tmp = _items[i];
            _items[i] = _items[j];
            _items[j] = tmp;
        }

        // -------------------------------------------------------
        // delegates used in this class

        public MyContainer<T> Merge(CompareDelegate cmp, MyContainer<T> other)
        {
            var i = 0;
            var j = 0;
            var finished = false;
            var res = new MyContainer<T>();

            while (!finished)
            {
                if (cmp(_items[i], other._items[j]) > 0)
                {
                    res.Add(other._items[j]);
                    j++;
                }
                else
                {
                    res.Add(_items[i]);
                    i++;
                }

                finished = i >= Count || j >= other.Count;
            }

            for (var k = i; k < Count; k++) res.Add(_items[k]);

            for (var k = j; k < other.Count; k++) res.Add(other._items[k]);

            return res;
        }

        public MyContainer<T> MergeFromTo(CompareDelegate cmp, int from, int mid, int to)
        {
            var i = from;
            var j = mid;
            var finished = false;
            var res = new MyContainer<T>();

            while (!finished)
            {
                if (cmp(_items[i], _items[j]) > 0)
                {
                    res.Add(_items[j]);
                    j++;
                }
                else
                {
                    res.Add(_items[i]);
                    i++;
                }

                finished = i >= mid || j >= to;
            }

            for (var k = i; k < mid; k++) res.Add(_items[k]);

            for (var k = j; k < to; k++) res.Add(_items[k]);

            return res;
        }

        public void ParSort(CompareDelegate cmp)
        {
            var m = Count / 2;
            Parallel.Invoke(
                () => SortFromTo(cmp, 0, m - 1),
                () => SortFromTo(cmp, m, Count - 1));
        }

        public void Sort(CompareDelegate cmp) => SortFromTo(cmp, 0, Count - 1);


        public void SortFromTo(CompareDelegate cmp, int from, int to)
        {
            // implements a naive bubble-sort
            var swapped = false;

            if (from < 0 || to > Count - 1) throw new Exception("SortFromTo: out of bounds");

            do
            {
                swapped = false;
                for (var i = from; i < to; i++)
                {
                    if (cmp(_items[i], _items[i + 1]) <= 0) continue;
                    Swap(i, i + 1);
                    swapped = true;
                }
            } while (swapped);
        }

        // an equivalent implementation using interface IComparable rather than delegates
        public void Sort0()
        {
            // no argument; the IComparable interface provides CompareTo
            // implements a naive bubble-sort
            var swapped = false;
            do
            {
                swapped = false;
                for (var i = 0; i <= Count - 2; i++)
                    if (_items[i].CompareTo(_items[i + 1]) > 0)
                    {
                        Swap(i, i + 1);
                        swapped = true;
                    }
            } while (swapped);
        }

        public bool IsSorted(CompareDelegate cmp)
        {
            for (var i = 0; i <= Count - 2; i++)
                if (cmp(_items[i], _items[i + 1]) < 0)
                    // error case
                    return false;

            return true;
        }

        // exceptions
        public class ContainerException : Exception
        {
            public ContainerException(string msg) : base(msg)
            {
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace Collection
{
    public partial class MyContainer<T> : ICollection<T> where T : IComparable<T>
    {
        // indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ContainerException($"get: index {index} out of bounds: [{0},{Count}]");

                return _items[index];
            }
            set
            {
                if (index >= Count) throw new ContainerException($"set: index {index} out of bounds: [{0},{Count}]");

                _items[index] = value;
            }
        }

        public bool IsSynchronized => false;

        public object SyncRoot { get; } = new { };
        // -------------------------------------------------------
        // ICollection implementation
        // see http://msdn.microsoft.com/en-us/library/92t2ye13.aspx

        public void Add(T t)
        {
            if (Count >= _items.Length)
                throw new ContainerException($"Reached max length of container: {_items.Length}");

            _items[Count++] = t;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T x)
        {
            foreach (var t in this)
                if (t.CompareTo(x) == 0)
                    // uses method from IComparable
                    return true;

            return false;
        }

        public bool Remove(T x)
        {
            throw new ContainerException("Remove method not implemented for MyContainer");
        }

        public void CopyTo(T[] arr, int arrInd)
        {
            var i = arrInd;
            foreach (var t in this) arr[i++] = t;
        }

        public int Count { get; private set; } // number of elements in the collection

        public bool IsReadOnly => false;

        public void CopyTo(Array arr, int index)
        {
            var i = index;
            foreach (var t in this) arr.SetValue(t, i++);
        }
    }
}
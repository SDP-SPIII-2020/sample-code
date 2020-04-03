using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    public partial class MyContainer<T> : IEnumerator<T> where T : IComparable<T>
    {
        // ------------------------------------------------------
        // IEnumerator implementation 
        // see http://msdn.microsoft.com/en-us/library/78dfe2yb.aspx

        public IEnumerator<T> GetEnumerator() => new MyEnumerator<T>(this);

        public bool MoveNext()
        {
            throw new ContainerException("MoveNext method not implemented for MyContainer");
        }

        public void Reset()
        {
            throw new ContainerException("Reset method not implemented for MyContainer");
        }

        public T Current { get; }

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private class MyEnumerator<T> : IEnumerator<T> where T : IComparable<T>
        {
            private readonly MyContainer<T> _thisCont;
            private int _currIdx;

            public MyEnumerator(MyContainer<T> cont)
            {
                _currIdx = -1; // NB: needs to start with -1; 
                _thisCont = cont;
            }

            public bool MoveNext()
            {
                if (_currIdx >= _thisCont.Count - 1) return false;

                _currIdx++;
                return true;
            }

            public void Reset()
            {
                _currIdx = -1;
            }

            object? IEnumerator.Current => Current;

            public T Current => _thisCont[_currIdx];

            public void Dispose()
            {
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
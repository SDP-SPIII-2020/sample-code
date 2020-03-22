using System;

namespace Iterator
{
    public class ConcreteIterator<T> : Iiterator<T>
    {
        private ConcreteAggregate<T> _aggregate;
        private int _current = 0;

        public ConcreteIterator(ConcreteAggregate<T> aggregate)
        {
            _aggregate = aggregate;
        }

        public T First() => _aggregate[0];

        public T Next()
        {
            var ret = default(T);
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        public bool IsFinished() => _current >= _aggregate.Count;

        public T CurrentItem() => _aggregate[_current];
    }
}
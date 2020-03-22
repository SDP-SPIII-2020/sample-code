using System.Collections.Generic;

namespace Iterator
{
    public class ConcreteAggregate<T>:  IAggregate<T>
    {
        private readonly List<T> _items = new List<T>();
        
        public Iiterator<T> CreateIterator() => new ConcreteIterator<T>(this);

        public int Count => _items.Count;
        
        // indexer
        public T this[int index]
        {
            get => _items[index];
            set => _items.Insert(index, value);
        }
    }
}
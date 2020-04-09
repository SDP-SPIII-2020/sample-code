using System.Collections.Generic;

namespace example03
{
    /// <summary>
    /// The aggregate interface
    /// </summary>
    public interface ISweetPacket
    {
        SweetIterator CreateIterator();
    }

    public class SweetBag : ISweetPacket
    {
        private readonly List<Sweet> _items = new List<Sweet>();

        public SweetIterator CreateIterator() => new SweetIterator(this);

        // Gets count of sweets
        public int Count => _items.Count;

        // Indexer
        public Sweet this[int index]
        {
            get => _items[index];
            set => _items.Add(value);
        }
    }
}
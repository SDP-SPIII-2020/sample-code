using System;

namespace example01
{
    /// <summary>
    /// A box can hold a particular thing
    /// </summary>
    /// <typeparam name="T">The type of the thing</typeparam>
    public class Box<T>
    {
        private T _item;

        public T Item
        {
            get => _item;
            private set
            {
                _item = value;
                IsEmpty = false;
            }
        }

        public bool IsEmpty = true;

        public Box()
        {
        }

        public Box(T newItem)
        {
            Item = newItem;
        }
    }

    public static class BoxExtensions
    {
        public static Box<TB> Select<TA, TB>(this Box<TA> box, Func<TA, TB> map)
        {
            if (box.IsEmpty) return new Box<TB>();
            var transformedItem = map(box.Item);
            return new Box<TB>(transformedItem);
        }
    }
}
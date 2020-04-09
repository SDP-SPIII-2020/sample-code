using System;

namespace example02
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
            // VETL - Validate, Extract, Transform, Lift

            // Validate
            if (box.IsEmpty) return new Box<TB>();

            // Extract
            var extracted = box.Item;

            // Transform
            var transformedItem = map(extracted);

            // Lift
            return new Box<TB>(transformedItem);
        }

        public static Box<TB> Bind<TA, TB>(this Box<TA> box, Func<TA, Box<TB>> bind) // Lift and Transform
        {
            // Validate
            if (box.IsEmpty) return new Box<TB>();

            // Extract
            var extracted = box.Item;

            // Transformation via a user-defined function (UDF) and Lift
            var transformedItemAndLifted = bind(extracted);

            return transformedItemAndLifted;
        }
    }
}
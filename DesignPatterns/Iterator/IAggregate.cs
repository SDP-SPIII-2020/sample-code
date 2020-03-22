namespace Iterator
{
    public interface IAggregate<T>
    {
        public Iiterator<T> CreateIterator();
    }
}
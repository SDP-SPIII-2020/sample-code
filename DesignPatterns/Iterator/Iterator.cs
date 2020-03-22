namespace Iterator
{
    public interface Iiterator<T>
    {
        public T First();
        public T Next();
        public bool IsFinished();
        public T CurrentItem();
    }
}
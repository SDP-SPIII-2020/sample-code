namespace example03
{
    /// <summary>
    /// The "Iterator" interface
    /// </summary>
    public interface ISweetIterator
    {
        Sweet First();
        Sweet Next();
        bool IsDone { get; }
        Sweet CurrentSweet { get; }
    }

    /// <summary>
    /// The "ConcreteIterator" class
    /// </summary>
    public class SweetIterator : ISweetIterator
    {
        private SweetBag _sweetBag;
        private int _current = 0;
        private int _step = 1;

        public SweetIterator(SweetBag sweets)
        {
            _sweetBag = sweets;
        }

        public Sweet First()
        {
            _current = 0;
            return _sweetBag[_current] as Sweet;
        }

        public Sweet Next()
        {
            _current += _step;
            if (!IsDone)
                return _sweetBag[_current] as Sweet;
            return null;
        }

        public bool IsDone => _current >= _sweetBag.Count;

        public Sweet CurrentSweet => _sweetBag[_current] as Sweet;
    }
}
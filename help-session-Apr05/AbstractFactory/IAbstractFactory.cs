namespace AbstractFactory
{
    /// <summary>
    /// The 'AbstractFactory' type
    /// </summary>
    public interface IAbstractFactory
    {
        public AbstractProductA CreateProductA();
        public AbstractProductB CreateProductB();
    }
}
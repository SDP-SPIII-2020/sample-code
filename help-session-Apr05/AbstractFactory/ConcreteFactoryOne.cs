namespace AbstractFactory
{
    /// <summary>
    /// The 'ConcreteFactoryOne' class
    /// </summary>
    internal class ConcreteFactoryOne : IAbstractFactory

    {
        public AbstractProductA CreateProductA() => new ProductA1();

        public AbstractProductB CreateProductB() => new ProductB1();
    }
}
namespace AbstractFactory
{
    /// <summary>
    /// The 'ConcreteFactoryTwo' class
    /// </summary>
    class ConcreteFactoryTwo : IAbstractFactory
    {
        public AbstractProductA CreateProductA() => new ProductA2();

        public AbstractProductB CreateProductB() => new ProductB2();
    }
}
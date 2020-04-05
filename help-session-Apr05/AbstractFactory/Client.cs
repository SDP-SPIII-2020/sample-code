namespace AbstractFactory
{
    /// <summary>
    /// Interactions for the products.
    /// </summary>
    internal class Client

    {
        private readonly AbstractProductA _abstractProductA;
        private readonly AbstractProductB _abstractProductB;

        // Constructor

        public Client(IAbstractFactory factory)
        {
            _abstractProductA = factory.CreateProductA();
            _abstractProductB = factory.CreateProductB();
        }

        public void Run()
        {
            _abstractProductB.WorksWith(_abstractProductA);
        }
    }
}
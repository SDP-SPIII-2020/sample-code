using System;

namespace AbstractFactory
{
    /// <summary>
    /// Abstract Factory Design Pattern.
    /// </summary>
    public static class Program
    {
        public static void Main()
        {
            // Abstract factory #1

            IAbstractFactory factory1 = new ConcreteFactoryOne();
            var client1 = new Client(factory1);
            client1.Run();

            // Abstract factory #2

            IAbstractFactory factory2 = new ConcreteFactoryTwo();
            var client2 = new Client(factory2);
            client2.Run();
        }
    }
}
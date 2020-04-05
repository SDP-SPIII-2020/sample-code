using System;

namespace AbstractFactory
{
    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    internal class ProductB1 : AbstractProductB
    {
        public override void WorksWith(AbstractProductA a)
        {
            Console.WriteLine(GetType().Name + " works with " + a.GetType().Name);
        }
    }
}
using System;

namespace AbstractFactory
{
    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    internal class ProductB2 : AbstractProductB
    {
        public override void WorksWith(AbstractProductA a)
        {
            Console.WriteLine(GetType().Name + " works with " + a.GetType().Name);
        }
    }
}
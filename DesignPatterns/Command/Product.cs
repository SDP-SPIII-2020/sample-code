using System;

namespace Command
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void IncreasePrice(decimal amount)
        {
            Price += amount;
            Console.WriteLine($"The price for {Name} has been increased by {amount}");
        }

        public void DecreasePrice(decimal amount)
        {
            if (amount >= Price) return;
            Price -= amount;
            Console.WriteLine($"The price for {Name} has been decreased by {amount}");
        }

        public override string ToString() =>
            $"Current price for the item {Name} is {Price}";
    }
}
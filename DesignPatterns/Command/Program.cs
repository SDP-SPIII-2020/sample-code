using System;

namespace Command
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("Tablet computer", 500.50m);
            
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 100m));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 5m));
            Execute(product,modifyPrice, new ProductCommand(product, PriceAction.Increase, 75m));
            
            Console.WriteLine(product);   
            Console.WriteLine(modifyPrice.ListCommands());
            
            modifyPrice.UndoActions();
            Console.WriteLine(product);   
            Console.WriteLine(modifyPrice.ListCommands());
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
using System;

namespace Command
{
    public class ProductCommand : ICommand
    {
        private readonly Product _product;
        private readonly PriceAction _priceAction;
        private readonly decimal _amount;

        public ProductCommand(Product product, PriceAction priceAction, decimal amount)
        {
            _product = product;
            _priceAction = priceAction;
            _amount = amount;
        }
        
        public void ExecuteAction()
        {
            switch (_priceAction)
            {
                case PriceAction.Increase:
                    _product.IncreasePrice(_amount);
                    break;
                case PriceAction.Decrease:
                    _product.DecreasePrice(_amount);
                    break;
                default:
                    Console.WriteLine($"Invalid action {_priceAction}!");
                    break;
            }
        }

        public void UndoAction()
        {
            switch (_priceAction)
            {
                case PriceAction.Increase:
                    _product.DecreasePrice(_amount);
                    break;
                case PriceAction.Decrease:
                    _product.IncreasePrice(_amount);
                    break;
                default:
                    Console.WriteLine($"Invalid action {_priceAction}!");
                    break;
            }
        }

        public override string ToString() => _priceAction.ToString();
    }
}
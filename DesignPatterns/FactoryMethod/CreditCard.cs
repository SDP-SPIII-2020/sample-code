namespace FactoryMethodDesignPattern
{
    public interface ICreditCard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();
    }

    public class Platinum : ICreditCard
    {
        public string GetCardType() => "Platinum Plus";

        public int GetCreditLimit() => 35000;

        public int GetAnnualCharge() => 2000;
    }

    public class Titanium : ICreditCard
    {
        public string GetCardType() => "Titanium Edge";

        public int GetCreditLimit() => 25000;

        public int GetAnnualCharge() => 1500;
    }

    public class MoneyBack : ICreditCard
    {
        public string GetCardType() => "MoneyBack";

        public int GetCreditLimit() => 15000;

        public int GetAnnualCharge() => 500;
    }
}
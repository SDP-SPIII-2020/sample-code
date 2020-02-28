namespace DependencyInjection
{
    public interface ICustomerDataAccess
    {
        string GetCustomerName(int id);
    }

    public class CustomerDataAccess : ICustomerDataAccess
    {
        public string GetCustomerName(int id) => "Dummy Customer Name";
    }
}
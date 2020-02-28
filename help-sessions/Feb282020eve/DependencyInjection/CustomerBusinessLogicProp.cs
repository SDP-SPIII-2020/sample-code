namespace DependencyInjection
{
    public class CustomerBusinessLogicProp
    {
        public ICustomerDataAccess DataAccess { get; set; }
        public string GetCustomerName(int id) => DataAccess.GetCustomerName(id);
    }
}
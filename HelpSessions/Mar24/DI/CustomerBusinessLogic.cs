namespace Mar24
{
    public class CustomerBusinessLogic
    {
        public ICustomerData CustomerData { get; set; }

        // public CustomerBusinessLogic(ICustomerData customerData)
        // {
        //     _customerData = customerData;
        // }

        public string GetCustomerName(int id) => CustomerData.GetCustomerName(id);
    }
}
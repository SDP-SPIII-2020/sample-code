namespace Mar24
{
    public static class DataAccessFactory
    {
        public static ICustomerData GetCustomerDataObject() => new CustomerData();
    }
}
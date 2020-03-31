using System;

namespace Mar24
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var cbl = new CustomerBusinessLogic {CustomerData = DataAccessFactory.GetCustomerDataObject()};
            
            cbl.GetCustomerName(1);
        }
    }
}
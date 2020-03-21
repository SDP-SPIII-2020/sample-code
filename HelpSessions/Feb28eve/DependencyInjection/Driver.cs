using System;
using NodaTime;

namespace DependencyInjection
{
    class Driver
    {
        static void Main(string[] args)
        {
            // tightly coupled
            // CustomerDataAccess icda = new CustomerDataAccess();
            
            // slightly less tightly coupled
            // ICustomerDataAccess icda = new CustomerDataAccess();
            
            // Use a factory to decouple the implementation
            // ICustomerDataAccess icda = DataAccessFactory.GetCustomerDataAccessObj();
            
            // DI via the constructor 
            //var cbl = new CustomerBusinessLogicCons(DataAccessFactory.GetCustomerDataAccessObj());
            //cbl.GetCustomerName(34);
            
            // DI via a property
            //var cbl = new CustomerBusinessLogicProp();
            //cbl.DataAccess = DataAccessFactory.GetCustomerDataAccessObj();
            //cbl.GetCustomerName(34);
            
            Instant now = SystemClock.Instance.GetCurrentInstant();

            for (long i = 0; i < 100000; i++)
            {
                //Console.WriteLine(i);
            }
            
            Instant last = SystemClock.Instance.GetCurrentInstant();

            Console.WriteLine(last-now);
        }
    }
}
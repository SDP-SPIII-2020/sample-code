namespace DependencyInjection
{
    public class CustomerBusinessLogicCons
    {
        private ICustomerDataAccess _customerDataAccess;

        public CustomerBusinessLogicCons(ICustomerDataAccess customerDataAccess)
        {
            _customerDataAccess = customerDataAccess;
        }

        public CustomerBusinessLogicCons()
        {
            _customerDataAccess = DataAccessFactory.GetCustomerDataAccessObj();
        }
        
        public string GetCustomerName(int id) => _customerDataAccess.GetCustomerName(id);
    }
}
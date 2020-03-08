namespace YetAnotherSOLIDExample
{
    public interface IManageEmployees : IAddOperation, IGetOperation, IRemoveOperation
    {
    }

    public interface IManageArchivalEmployees : IGetOperation
    {
    }

    public interface IAddOperation
    {
        bool AddEmployeeToPayroll();
    }

    public interface IGetOperation
    {
        bool GetEmployeeFromPayroll();
    }

    public interface IRemoveOperation
    {
        
    }
}
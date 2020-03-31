namespace YetAnotherSOLIDExample
{
    public interface IEmployee
    {
        int Id { get; set; }
        string Name { get; set; }

        string GetEmployeeDetails();
    }

    public interface IZeroHoursEmployee : IEmployee
    {
    }

    public interface IContractedEmployee : IEmployee
    {
    }
}
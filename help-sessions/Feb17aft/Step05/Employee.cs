namespace YetAnotherSOLIDExample
{
    public abstract class Employee : IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public abstract string GetEmployeeDetails();
    }
}
namespace YetAnotherSOLIDExample
{
    public class ZeroHoursEmployee: Employee, IZeroHoursEmployee
    {
        public override string GetEmployeeDetails() => "Zero";
    }
}
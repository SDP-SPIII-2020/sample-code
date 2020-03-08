namespace YetAnotherSOLIDExample
{
    public class ContractedEmployee : Employee, IContractedEmployee
    {
        public override string GetEmployeeDetails() => "Contracted";
    }
}
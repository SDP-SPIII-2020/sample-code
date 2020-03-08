using System;
using System.Collections.Generic;

namespace YetAnotherSOLIDExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IEmployee> employeeList = new List<IEmployee>();
            employeeList.Add(new ContractedEmployee());
            employeeList.Add(new ZeroHoursEmployee());
            employeeList.Add(new ContractedEmployee());
            
            employeeList.ForEach(x => Console.WriteLine(x.GetEmployeeDetails()));
        }
    }
}
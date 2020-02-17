using System;
using System.Collections.Generic;

namespace YetAnotherSOLIDExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeList = YASEFactory.GetContainer();
            employeeList.Add(YASEFactory.GetInstance("Contracted"));
            employeeList.Add(YASEFactory.GetInstance("ZeroHours"));
            employeeList.Add(YASEFactory.GetInstance());
            employeeList.Add(YASEFactory.GetInstance("ZeroHours"));
            
            employeeList.ForEach(x => Console.WriteLine(x.GetEmployeeDetails()));
        }
    }
}
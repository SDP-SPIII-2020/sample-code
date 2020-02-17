using System.Collections.Generic;

namespace YetAnotherSOLIDExample
{
    public static class YASEFactory
    {
        public static List<IEmployee> GetContainer() => new List<IEmployee>();

        public static IEmployee GetInstance(string s = "Contracted") =>
            s switch
            {
                "Contracted" => new ContractedEmployee(),
                "ZeroHours" => new ZeroHoursEmployee(),
                _ => new ContractedEmployee()
            };
    }
}

/*
            IEmployee em;
            switch (s)
            {
                case "Contracted":
                    em = new ContractedEmployee();
                    break;
                case "ZeroHours":
                    em = new ZeroHoursEmployee();
                    break;
                default:
                    em = new ContractedEmployee();
                    break;
            }

            return em;
            */
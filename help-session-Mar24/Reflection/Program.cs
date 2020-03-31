using System;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    public static class Program
    {
        public static void Main()
        {
            Type type = typeof(Customer);
            Console.WriteLine($"Type is {type.Name} Namespace: {type.Namespace} Full name: {type.FullName}");
            
            PropertyInfo[] propertyInfos = type.GetProperties();
            Console.WriteLine($"The list of properties of the {type.Name} class are:");
            propertyInfos.ToList().ForEach(x => Console.WriteLine(x.Name));

            ConstructorInfo[] customerInfo = type.GetConstructors();
            Console.WriteLine($"The list of constructors for {type.Name} are:");
            customerInfo.ToList().ForEach(Console.WriteLine);

            MethodInfo[] methodInfo = type.GetMethods();
            Console.WriteLine($"The list of methods for {type.Name} are:");
            methodInfo.ToList().ForEach(Console.WriteLine);
            // note that the backing methods for the Properties are also displayed.
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public bool Validate(Customer customer) => true;
    }
}
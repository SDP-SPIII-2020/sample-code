// Example demonstrating class hierarchies and inheritance
// -----------------------------------------------------------------------------

using System;

namespace Person
{
    internal class Person
    {
        // data fields for Person; uses a mixture of access modifiers for demonstration purposes
        public string FName;
        private readonly string _lName;
        private readonly string _address;

        public Person(string fName, string lName, string address)
        {
            FName = fName;
            _lName = lName;
            _address = address;
        }

        // explicit, public access methods to the data fields
        public string GetfName() => FName;

        public string GetlName() => _lName;

        public string GetAddress() => _address;

        public override string ToString() => $"Name: {GetfName()} {GetlName()}\tAddress: {_address}";
    }

    // Student is a sub-class of Person, and inherits its data-fields and methods
    internal class Student : Person
    {
        // data fields for Student
        private readonly string _studentNo;
        private readonly string _degree;

        public Student(string fName, string lName, string address, string studentNo, string degree)
            : base(fName, lName, address)
        {
            _studentNo = studentNo;
            _degree = degree;
        }

        // explicit, public access methods to the data fields
        public string GetStudentNo() => _studentNo;

        public string GetDegree() => _degree;

        // override ToString as an example of serialisation
        public override string ToString()
        {
            var baseStr = base.ToString();
            var thisStr = $"StudentNo: {GetStudentNo()}\tDegree: {GetDegree()}";
            return baseStr + "\n" + thisStr;
        }
    }

    // Lecturer is another sub-class of Person, and inherits its data-fields and methods
    internal class Lecturer : Person
    {
        // data fields for Lecturer
        private readonly string _officeNo;

        public Lecturer(string fName, string lName, string address, string officeNo)
            : base(fName, lName, address)
        {
            _officeNo = officeNo;
        }

        // explicit, public access methods to the data fields
        public string GetOfficeNo() => _officeNo;

        // override ToString as an example of serialisation
        public override string ToString()
        {
            var baseStr = base.ToString();
            var thisStr = $"OfficeNo: {GetOfficeNo()}";
            return baseStr + "\n" + thisStr;
        }
    }

    internal static class Test
    {
        public static void Main()
        {
            Person p = new Person("John", "Smith", "Bristol");
            Student s = new Student("Brian", "Cartman", "London", "99678", "CS");
            Lecturer l = new Lecturer("Fred", "Bloggs", "Birmingham", "N12");
            Console.WriteLine("\nInstantiating a person p, student s and lecturer l");
            Console.WriteLine($"Person p: {p} ");
            Console.WriteLine($"Student s: {s} ");
            Console.WriteLine($"Lecturer l: {l} ");
            Console.WriteLine("\nBasic tests, showing values after instantiating basic objects:");
            Console.WriteLine($"Student no: {s.GetStudentNo()} ");
            Console.WriteLine($"Student address: {s.GetAddress()} ");
            Console.WriteLine($"Person address: {p.GetAddress()} ");
            Console.WriteLine($"Lecturer address: {l.GetAddress()} ");
            Console.WriteLine($"Lecturer office: {l.GetOfficeNo()} ");
            // ---

            Console.Write(
                "\nNow, copying the object and updating first name, demonstrating reference semantics in objects, i.e.,");
            Console.WriteLine("the update of first name in q affects p, too");
            var q = p;
            Console.WriteLine($"Person p: {p} ");
            Console.WriteLine($"Person q: {q} ");
            q.FName = "Will";
            Console.WriteLine($"Person p: {p} ");
            Console.WriteLine($"Person q: {q} ");

            Console.WriteLine(
                "\nHere we use the overriden ToString() method, implemented as a generic serialisation method:");
            Console.WriteLine($"Student: {s} ");
            Console.WriteLine($"Student: {s} ");
            Console.WriteLine($"Lecturer: {l} ");
        }
    }
}
// Example demonstrating class hierarchies and inheritance
// Implicit and explicit serialisation
// This version uses pre-defined attributes (see Liberty, "Programming C# 3.0", Chapter 20)
// See also: https://msdn.microsoft.com/en-us/library/4abbf6k0%28v=vs.110%29.aspx
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialise
{
    internal static class Test
    {
        public static void Main()
        {
            // Person p = new Person("John", "Smith", "Edinburgh");
            var s = new Student("Brian", "Cartman", "London", "94678", "CS");
            var l = new Lecturer("Fred", "Bloggs", "Bristol", "B18");
            Console.WriteLine(
                "\nHere we use the overriden ToString() method, implemented as a generic serialisation method:");
            Console.WriteLine($"Student: {s} ");
            Console.WriteLine($"Lecturer: {l} ");

            /* ------------------------------------------------------- */
            IFormatter formatter = new BinaryFormatter();
            Stream streamOut = new FileStream("Person.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(streamOut, l);
            streamOut.Close();
            /* ------------------------------------------------------- */
            // IFormatter formatter = new BinaryFormatter();
            Stream streamIn = new FileStream("Person.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Lecturer l1 = (Lecturer) formatter.Deserialize(streamIn);
            streamIn.Close();
            // Test the result: contents should be the same as in l
            Console.WriteLine($"Lecturer after serialize/deserialize:\n{l1}");
        }
    }
}
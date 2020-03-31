using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

// Example demonstrating class hierarchies and inheritance using implicit and explicit serialisation
// See also: https://msdn.microsoft.com/en-us/library/4abbf6k0%28v=vs.110%29.aspx
// -----------------------------------------------------------------------------

namespace ReflectionSerialisation
{
    public static class Program
    {
        public static void Main()
        {
            var s = new Student("Brian", "Hillman", "London", "99124678", "CS");
            var l = new Lecturer("Hans-Wolfgang", "Loidl", "Edinburgh", "G48");
            Console.WriteLine(
                $"\nHere we use the overriden ToString() method, implemented as a generic serialisation method:\n");
            Console.WriteLine($"Student: {s}\n{s.GetHashCode()}");
            Console.WriteLine($"Lecturer: {l}\n{l.GetHashCode()}");

            /* ------------------------------------------------------- */
            IFormatter formatter = new BinaryFormatter();
            Stream streamOut = new FileStream("ThisPerson.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(streamOut, l);
            streamOut.Close();

            /* ------------------------------------------------------- */
            Stream streamIn = new FileStream("ThisPerson.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            var l1 = formatter.Deserialize(streamIn) as Lecturer;
            streamIn.Close();

            // Test the result: contents should be the same as in l
            Console.WriteLine($"\nLecturer after serialise/deserialize:\n{l1}\n{l1.GetHashCode()}");
        }
    }
}
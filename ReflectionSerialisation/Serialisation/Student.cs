using System;

namespace ReflectionSerialisation
{
    // Student is a sub-class of Person, and inherits its data-fields and methods
    [Serializable]
    internal class Student : Person
    {
        // the properties to access the data
        public string Degree { get; set; }
        public string StudentNo { get; set; }

        // constructor
        public Student(string fName, string lName, string address, string studentNo, string degree) :
            base(fName, lName, address)
        {
            StudentNo = studentNo;
            Degree = degree;
        }

        /* ------------------------------------------------------- */
        /* This does explicit serialisation; we don't need that with the serializable attribute */
        // override ToString as an example of serialisation
        public override string ToString()
        {
            var baseStr = base.ToString();
            var thisStr = $"Student No: {StudentNo}\tDegree: {Degree}";
            return baseStr + thisStr;
        }
    }
}
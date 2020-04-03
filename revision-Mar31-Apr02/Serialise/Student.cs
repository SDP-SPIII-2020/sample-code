using System;

namespace Serialise
{
    [Serializable]
    internal class Student : Person
    {
        // the private data for Student
        private string _studentNo;
        private string _degree;

        // the properties to access the data
        public string Degree
        {
            get => _degree;
            set => _degree = value;
        }

        public string StudentNo
        {
            get => _studentNo;
            set => _studentNo = value;
        }

        // constructor
        public Student(string fName, string lName, string address, string studentNo, string degree)
            : base(fName, lName, address)
        {
            StudentNo = studentNo;
            Degree = degree;
        }

        /* ------------------------------------------------------- */
        /* This does explicit serialisation; we don't need that with the serialisable attribute */
        // override ToString as an example of serialisation
        public override string ToString()
        {
            var baseStr = base.ToString();
            var thisStr = $"StudentNo: {StudentNo}\tDegree: {Degree}";
            return baseStr + "\n" + thisStr;
        }
    }
}
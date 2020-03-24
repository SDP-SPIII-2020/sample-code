using System;

namespace ReflectionSerialisation
{
    // Lecturer is another sub-class of Person, and inherits its data-fields and methods
    [Serializable]
    class Lecturer : Person
    {
        public string OfficeNo { get; set; }

        public Lecturer(string fName, string lName, string address, string officeNo) : base(fName, lName, address)
        {
            OfficeNo = officeNo;
        }

        // override ToString as an example of serialisation
        public override string ToString() => base.ToString() + $" OfficeNo: {OfficeNo}" + "\n";
    }
}
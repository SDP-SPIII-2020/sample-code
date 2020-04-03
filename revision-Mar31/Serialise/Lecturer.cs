using System;

namespace Serialise
{
    [Serializable]
    internal class Lecturer : Person
    {
        private string _officeNo;

        // the property to access the data
        public string OfficeNo
        {
            get => _officeNo;
            set => _officeNo = value;
        }

        public Lecturer(string fName, string lName, string address, string officeNo) : base(fName, lName, address)
        {
            OfficeNo = officeNo;
        }

        /* ------------------------------------------------------- */
        /* This does explicit serialisation; we don't need that with the serialisable attribute */
        // override ToString as an example of serialisation
        public override string ToString()
        {
            var baseStr = base.ToString();
            var thisStr = $"OfficeNo: {OfficeNo}";
            return baseStr + "\n" + thisStr;
        }
    }
}
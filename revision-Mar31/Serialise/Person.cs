using System;

namespace Serialise
{
    [Serializable]
    internal class Person
    {
        // private data fields for Person; uses a mixture of access modifiers for demonstration
        private string _fName;
        private string _lName;
        private string _address;

        // public properties to access the data
        public string FName
        {
            get => _fName;
            set => _fName = value;
        }

        public string LName
        {
            get => _lName;
            set => _lName = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public Person(string fName, string lName, string address)
        {
            FName = fName;
            LName = lName;
            Address = address;
        }

        public override string ToString() => $"Name: {FName} {LName}\tAddress: {Address}";

        public virtual string Serialise() => "Person.Serialise: To be implemented";
    }
}
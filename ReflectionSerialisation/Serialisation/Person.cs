using System;

namespace ReflectionSerialisation
{
    // The base class: generic information on a person
    [Serializable]
    internal class Person
    {
        // public properties to access the data
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }

        public Person(string fName, string lName, string address)
        {
            FName = fName;
            LName = lName;
            Address = address;
        }

        public override string ToString() => $"Name: {FName} {LName}\tAddress: {Address}";
    }
}
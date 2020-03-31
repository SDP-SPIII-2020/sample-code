namespace LINQ
{
    public class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public override string ToString() => $"Name is {Name}, Id is {Id}, Age is {Age}";
    }
}
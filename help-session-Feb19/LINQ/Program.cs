using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Channels;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student() {Name = "Fred", Id = "abc", Age = 21},
                new Student() {Name = "Betty", Id = "def", Age = 29},
                new Student() {Name = "John", Id = "ghi", Age = 31},
                new Student() {Name = "Mary", Id = "rst", Age = 41},
                new Student() {Name = "Fish", Id = "zzz", Age = 61}
            };

            studentList.ToList().ForEach(Console.WriteLine);
            // foreach (var st in studentList)
            // {
            //     Console.WriteLine(st);
            // }

            var output = studentList.Where(s => s.Age > 30)
                .Select(s => s) 
                .OrderBy(s => s.Age)
                //.Where(st => string.Compare(st.Name, "Dish", StringComparison.Ordinal) > 0)
                .Select(s => s.Name);

            output.ToList().ForEach(Console.WriteLine);

            // var output2 = from s in studentList
            //     group s by s.Age
            //     into temp
            //     orderby temp.Key
            //     select new {temp.Key};
            // output2.ToList().ForEach(Console.WriteLine);
        }
    }
}
using System;
using System.Linq.Expressions;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = default(string);
            Console.WriteLine("Hello World!");
        }
    }

    class Parent
    {
        public Parent(string s)
        {
        }
    }

    class Child : Parent
    {
        public Child() : base(default(string)) // okay until base constructor is private
        {
        }
    }
}
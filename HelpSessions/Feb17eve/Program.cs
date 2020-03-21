using System;

namespace Feb17ev
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            A b = new B();
            A c = new C();
            
            Console.WriteLine(a.Output());
            Console.WriteLine(b.Output());
            Console.WriteLine(c.Output());
        }
    }

    class A
    {
        public virtual string Output() => "A";
    }

    class B : A
    {
        public new string Output() => "B";
    }

    class C : B
    {
        public new string Output() => "C";
    }
}
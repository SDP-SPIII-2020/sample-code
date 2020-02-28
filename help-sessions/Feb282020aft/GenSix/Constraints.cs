using System;
using System.Collections.Generic;

namespace GenSix
{
    class Constraints
    {
        static void Main(string[] args)
        {
            var aList = new List<IThing>();
            aList.Add(new A());
            Method(aList);
            
            var bList = new List<B>();
            bList.Add(new B(34));
            Method(bList);
            
            var cList = new List<C>();
            cList.Add(new C());
            //Method(cList);

            var sillyList = new List<bool>();
            Init(sillyList);
            Method(sillyList);
        }

        static void Method<T>(List<T> aList)
        {
            aList.ForEach(x => Console.WriteLine($"{x}"));
            Console.WriteLine($"typeof(T) = ${typeof(T)}");
        }

        static void Init<T>(List<T> aList) where T : notnull
        {
            aList.Add(default(T)); // = new T();
        }
        
        // where T : class
        // where T : struct
        
        // Outer<string>.Inner<string>
        // Outer<string>.Inner<int>
    }

    interface IThing 
    {}
    
    class A: IThing
    {}

    class B : IThing
    {
        internal B(int x)
        {
        }
    }
    
    class C
    {}

    class Outer<TOuter>
    {
        internal class Inner<TInner>
        {
            static int value;
        }
    }
    class LinkedList<T>
    {
        class Node<T>
        {
        
        }
    }
}


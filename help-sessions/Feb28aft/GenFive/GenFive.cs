using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace GenFive
{
    class GenFive
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.Add(3);
            numbers.Add(12);
            numbers.Add(16);
            numbers.Add(8);
            numbers.Add(2);

            List<int> SubList = CopyAtMost(numbers, 6);
            SubList.ForEach(num => Console.WriteLine($"Number is {num}"));
        }
        
        static List<Fred> CopyAtMost<Fred>(List<Fred> input, int number)
        {
            var actualCount = Math.Min(input.Count, number);
            var ret = new List<Fred>();
            for (var i = 0; i < actualCount; i++)
            {
                ret.Add(input[i]);
            }

            return ret;
        }
    }
}

// public void Method() {} --- non-generic method which has "arity" 0
// public void Method<T>() {} --- generic method with arity 1
// public void Method<T1,T2>() {} --- generic with arity 2

// class, struct, delegate, interface
// fields, properties, indexers, cons, events, finalizers

// public interface IHowOdd<T1,T2,T3,T4> {} --- is this a good idea?

// public void Method<T1>() {}
// public void Method<T2>() {} 

// Compiler will not allow T1 and T2 as it won't be able to differentiate between the two instantiations.
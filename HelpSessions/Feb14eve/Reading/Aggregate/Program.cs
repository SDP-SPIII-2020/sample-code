using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Aggregate
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = {1, 4, 8, 12, 0, 3, 7, 11, 15, 6};
            Predicate<int> even = (next) => (next % 2 == 0);

            //PrintList(ints);
            ints.ToList().ForEach(item => Console.Write((even(item)) ? $" {item}" : ""));
            Console.WriteLine();
            // map
            var result = ints.Select(x => x + 3);
            result = from item in ints select item + 3;
            
            result.ToList().ForEach(x => Console.Write($" {x}"));
            Console.WriteLine();
            // filter
            result = ints.Where(x => even(x));
            result.ToList().ForEach(x => Console.Write($" {x}"));
            Console.WriteLine();
            
            // reduce
            Console.WriteLine(ints.Aggregate(0, (count, next) => 
               TestEven(next) ? count + 1: count));
            Console.WriteLine(ints.Aggregate(0, TestAndCount));
            Console.WriteLine(ints.Aggregate(0, (x, y) => (TestEven(y) ? x + 1 : x)));
            Console.WriteLine(ints.Aggregate(1, (x,y) => x * y)); 
            
            var res = ints.Zip(ints.Reverse()); 
                //.ToList().ForEach(x => Console.Write($" {x}"));
        }

        static void PrintList<T>(T[] arr) where T: IEnumerable<T>
        {
            foreach (var item in arr)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();
        }
        static int TestAndCount(int count, int next)
        {
            if (TestEven(next))
            {
                return count + 1;
            }

            return count;
        }
        static bool TestEven(int next)
        {
            return (next % 2 == 0);
        }

        #region Length of string
#if THING
        {
            string[] fruit = {"apple", "orange", "pear", "banana", "mango"};

            var res = fruit.Aggregate("apple",
                (longestItem, nextItem) =>
                    nextItem.Length > longestItem.Length ? nextItem : longestItem).ToUpper();
                
            Console.WriteLine(res);
        }
#endif
        #endregion 
    }
}
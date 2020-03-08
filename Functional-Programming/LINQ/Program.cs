/*
 * Quantify — All, Any, Contains
 * Filter — Where, OfType
 * Project/Transform — Select, SelectMany, Zip
 * Criteria/Set — Distinct, Except, Intersect, Union
 * Sorting — OrderBy, OrderByDecending, ThenBy, ThenByDecending, Reverse
 * Aggregation — Aggregate, Average, Count, LonCount, Max, Min, Sum
 * Partition/Join — Skip, SkipWhile, Take, TakeWhile, Join, GroupJoin
 * Grouping — GroupBy, ToLookup
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    internal static class Program
    {
        static void Main()
        {
           var collection = new List<int> {1, 2, 3, 4, 5};

            // Imperative style of programming is verbose
            // var results = new List<int>();
            // foreach (var num in collection)
            // {
            //     if (num % 2 != 0)
            //         results.Add(num);
            // }
            // // (x) => { ... } 
            // results.ForEach(x => Console.Write(x + " "));
            // Console.WriteLine();

            // Declarative is more concise
            collection.Where(num => num % 2 != 0).ToList().ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }
    }
}
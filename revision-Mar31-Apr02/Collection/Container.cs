// Container example using "advanced" C# constructs:
//
// . indexers
// . generics
// . collections
// . exceptions
// . delegates
// -----------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace Collection
{
    public class Tester
    {
        private static int int_lt(int i, int j)
        {
            if (i == j) return 0;

            if (i < j)
                return -1;
            return 1;
        }

        private static int int_gt(int i, int j)
        {
            return -1 * int_lt(i, j);
        }

        public static void Main()
        {
            var cont = new MyContainer<string>("One", "Two", "Three", "Four");
            var tst = new Tester();

            Console.WriteLine($"Container of strings initialised, containing {cont.Count} items");
            // direct write access
            try
            {
                cont[4] = "Five";
            }
            catch (MyContainer<string>.ContainerException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(
                    $"Implementation restriction: can only write to an existing field; currently only fields up to {cont.Count - 1} exist");
            }

            // direct read access
            Console.WriteLine("Printing contents using for loop: ");
            for (var i = 0; i < cont.Count; i++) Console.WriteLine($"cont[{i}]: {cont[i]}");

            // make use of IEnumerable implementation
            Console.WriteLine("Printing contents using foreach loop: ");
            foreach (var s in cont) Console.WriteLine($"Value: {s}");

            Console.WriteLine("Sorting contents alphabetically (delegate version) ...");
            var cmpLt = new MyContainer<string>.CompareDelegate(string.Compare);
            cont.Sort(cmpLt);
            cont.Print();
            Console.WriteLine("Reverse sorting contents alphabetically (delegate version) ...");

            var cmpGt =
                new MyContainer<string>.CompareDelegate((s1, s2) =>
                    -1 * string.CompareOrdinal(s1, s2));
            cont.Sort(cmpGt);
            cont.Print();

            Console.WriteLine("Sorting contents alphabetically (IComparable version) ...");
            cont.Sort0();
            cont.Print();

            // container with int contents
            var intArr = new[] {8, 4, 6, 2};
            var intCont = new MyContainer<int>(intArr);
            Console.WriteLine($"Container of int initialised, containing {intCont.Count} items");
            Console.WriteLine("Sorting contents ...");

            MyContainer<int>.CompareDelegate cmpIntLt = int_lt;
            intCont.Sort(cmpIntLt);
            intCont.Print();
            Console.WriteLine("Reverse sorting contents ...");

            var cmpIntGt = new MyContainer<int>.CompareDelegate(int_gt);
            intCont.Sort(cmpIntGt);
            intCont.Print();
            Console.WriteLine("Sorting contents (IComparable version) ...");
            intCont.Sort0();
            intCont.Print();

            Para(cmpIntLt, cmpIntGt);
        }
        
        // -----------------------------------------------------------------------------
        // Parallelism Example:
        //
        // Generate a sizable list, and sort it in ascending and descending order, in parallel.
        //
        private static void Para(MyContainer<int>.CompareDelegate cmpIntLt, MyContainer<int>.CompareDelegate cmpIntGt)
        {
            var rg = new Random(1701); // fix a seed for deterministic results
            var ic1 = new MyContainer<int>();
            for (var i = 0; i < MyContainer<int>.MaxItems; i++) ic1.Add(rg.Next());

            Console.WriteLine("Input array:");
            ic1.Print();

            var ic2 = (MyContainer<int>) ic1.Clone();
            Console.WriteLine("Sorting a random array ...");

            /* sequential code: */
            ic1.Sort(cmpIntLt);
            ic2.Sort(cmpIntGt);

            /* parallel code: */
            Parallel.Invoke( // generate two parallel threads
                () => ic1.Sort(cmpIntLt),
                () => ic2.Sort(cmpIntGt));

            /* parallelised sorting algorithm:  */
            ic1.ParSort(cmpIntLt);
            ic2.ParSort(cmpIntGt);

            Console.WriteLine("Sorted (ascending):");
            ic1.Print();
            Console.WriteLine("Sorted?: {0}", ic1.IsSorted(cmpIntLt).ToString());

            Console.WriteLine("Sorted (descending):");
            ic2.Print();
            Console.WriteLine("Sorted?: {0}", ic2.IsSorted(cmpIntGt).ToString());
        }
    }
}
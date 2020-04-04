using System;

namespace QuickSort
{
    public static class Tester
    {
        private const int MaxVal = 1000; // bound on values
        private const int Iterations = 1; // number of tests to run

        public delegate int MyIntDelegate(int x, int y);

        // sorting function: ascending order of integers
        private static GenSort<int>.Cmp IntCmp(int x, int y)
        {
            if (x > y)
                return GenSort<int>.Cmp.Gt;
            return x == y ? GenSort<int>.Cmp.Eq : GenSort<int>.Cmp.Lt;
        }

        // sorting function: descending order of integers
        private static GenSort<int>.Cmp IntCmpInv(int x, int y)
        {
            if (x > y)
                return GenSort<int>.Cmp.Lt;
            return x == y ? GenSort<int>.Cmp.Eq : GenSort<int>.Cmp.Gt;
        }

        private static bool EqArr<T>(T[] arr1, T[] arr2)
        {
            var n = arr1.Length < arr2.Length ? arr1.Length : arr2.Length;
            var ok = true;
            for (var i = 0; ok && i < n; i++)
            {
                ok &= arr1[i].Equals(arr2[i]);
            }

            return ok && arr1.Length == arr2.Length;
        }

        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: <prg> <v> <n> <t>");
                Console.WriteLine("v ... version (0: ascending order; 1: descending order)");
                Console.WriteLine("n ... list length");
                Console.WriteLine("t ... threshold for generating parallelism");
            }
            else
            {
                var v = Convert.ToInt32(args[0]);
                var n = Convert.ToInt32(args[1]);
                var t = Convert.ToInt32(args[2]);

                GenSort<int>.CmpDelegate theCmp;

                // an instance of the sorter class, using int comparison
                var myGenSortAsc = new GenSort<int>(IntCmp);
                var myGenSortDesc = new GenSort<int>(IntCmpInv);

                var seed = 1701 + 13 * n;
                for (var j = 0; j < Iterations; j++)
                {
                    var rg = new Random((seed + j * 7) % 65535); // fix a seed for deterministic results
                    var arr = new int[n];
                    Console.WriteLine($"Generating an array of size {n} ...");
                    for (var i = 0; i < n; i++)
                    {
                        arr[i] = rg.Next() % MaxVal;
                    }

                    // copy the array, to allow in-place sorting
                    var arr1 = (int[]) arr.Clone();

                    GenSort<int> theGenSort;
                    switch (v)
                    {
                        // sequential sort
                        case 0:
                            Console.WriteLine($"Sequential quick-sort, ascending order (size {n}) ...");
                            theGenSort = myGenSortAsc;
                            theCmp = IntCmp;
                            break;
                        case 1:
                            Console.WriteLine($"Sequential quick-sort, descending order (size {n}) ...");
                            theGenSort = myGenSortDesc;
                            theCmp = IntCmpInv;
                            break;
                        default:
                            Console.WriteLine($"Unknown version {v}; use 0: sequential");
                            continue;
                    }

                    theGenSort.SequentialQuickSort(arr);
                    /* test whether the result is Sorted */
                    try
                    {
                        Console.WriteLine($"Sorted?: {theGenSort.IsSorted(arr)}");
#if PRINT
	                    Console.WriteLine(theGenSort.ShowArray(arr,0, arr.Length-1));
#endif
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Some test failed!!!");
                        Console.WriteLine(theGenSort.ShowArray(arr, 0, arr.Length - 1));
                    }

                    /* another way to test whether the result is sorted, using built-in sort */
                    // use built-in sort on arrays; Comparison function needs int as return val, but should behave as defined!
                    Array.Sort(arr1, (x, y) => (int) theCmp(x, y));
                    if (EqArr(arr, arr1)) // use our own impl. of value eq
                        Console.WriteLine(".. result OK");
                    else
                    {
                        Console.WriteLine("** result WRONG");
                        Console.WriteLine("** should be " + theGenSort.ShowArray(arr1, 0, arr1.Length - 1));
                    }
                }
            }
        }
    }
}
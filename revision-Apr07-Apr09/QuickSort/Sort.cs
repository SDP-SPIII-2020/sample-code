/* 
    A generic sorting algorithm that uses delegates for the comparison operator.
*/

// -----------------------------------------------------------------------------
// configuration: pre-processing flags to turn on or off

// uncomment the line below to enable/disable debugging
// #define DEBUG

// uncomment the line below to print/suppress output of the sorted list
// #define PRINT

using System;

namespace QuickSort
{
    public class GenSort<T>
    {
        // enumeration for results of a generic comparison function
        // NB: the mapping to values is designed to conform with System.Comparison<T>
        public enum Cmp
        {
            Gt = 1,
            Eq = 0,
            Lt = -1
        };

        // this delegate defines a predicate over the list elements; mainly for testing
        // see also (using System): public delegate int Comparison<in T>
        public delegate Cmp CmpDelegate(T x, T y);

        // the actual function to compare something
        private readonly CmpDelegate _theCmp;

        public GenSort(CmpDelegate cmp)
        {
            _theCmp = cmp;
        }

        // -------------------------------------------------------
        // auxiliary functions

        private static void Swap(T[] array, int i, int j)
        {
            // requires: 0 <= i,j, <= array.Length-1

            if (i < 0 || i > array.Length - 1 || j < 0 || j > array.Length - 1)
            {
                throw new Exception("Swap: indices out of bounds");
            }

            if (i == j)
            {
                return;
            }

            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        // -------------------------------------------------------
        // QuickSort

        private int Partition(T[] array, int from, int to, int pivot)
        {
            // requires: 0 <= from <= pivot <= to <= array.Length-1
#if DEBUG
            int oldFrom = from, oldTo = to;
#endif
            int? lastPivot = null;
            var pivotVal = array[pivot];
#if DEBUG
            if (to - from < 1)
            {
                throw new Exception(
                    $"Partition: cannot partition a 1 element array (from={from}, to={to}): ");
            }
#endif
            if (from < 0 || to > array.Length - 1 || pivot < from || pivot > to)
            {
                throw new Exception(
                    $"Partition: indices out of bounds: from={from}, pivot={pivot}, to={to}, Length={array.Length}");
            }

            while (from < to)
            {
                if (_theCmp(array[from], pivotVal) == Cmp.Gt)
                {
                    // using DELEGATE
                    // if (array[from]>pivot_val) { // using delegate
                    Swap(array, from, to);
                    to--;
                }
                else
                {
                    if (_theCmp(array[from], pivotVal) == Cmp.Eq)
                    {
                        lastPivot = from;
                    }

                    from++;
                }
            }

            if (!lastPivot.HasValue)
            {
                if (_theCmp(array[from], pivotVal) == Cmp.Eq)
                {
                    return from;
                }

                throw new Exception($"Partition: pivot element {pivotVal} not found");
            }

            if (_theCmp(array[from], pivotVal) == Cmp.Gt)
            {
                // bring pivot element to end of lower half
                Swap(array, (int) lastPivot, from - 1);
                return from - 1;
            }

            // done, bring pivot element to end of lower half
            Swap(array, (int) lastPivot, @from);
            return @from;

            // provides: forall from <= i <= from. array[i]<=array[from] && 
            //           forall from+1 <= i <= to. array[i]>array[from] &&
        }

        private void SequentialQuickSort(T[] array, int from, int to, int level)
        {
            // requires: 0 <= from <= to <= array.Length-1
#if DEBUG
            var str = Indent(level);
#endif
            if (to - from < 1)
            {
                // a 1 elem list is sorted, per definitionem
                return;
            }
#if DEBUG
            Console.WriteLine(str + " Input: " + ShowArray(array, @from, to));
#endif
            var pivot = @from + (to - @from) / 2;
            pivot = Partition(array, @from, to, pivot);
#if DEBUG
            if (!IsPartition(array, @from, to, pivot))
            {
                throw new Exception($"segment from {@from} to {to} (pivot {pivot}) is not a partition");
            }

            Console.WriteLine(str + $" partitioning with pivot index {pivot} value {array[pivot]}... ");
#endif
            // recursive call on lower segment
            SequentialQuickSort(array, @from, pivot - 1, level + 1);
            // assert: IsSorted(array, from, pivot)
#if DEBUG
            Console.WriteLine(str + " Sorted Lower: " + ShowArray(array, @from, pivot - 1));
#endif
            // recursive call on upper segment
            SequentialQuickSort(array, pivot + 1, to, level + 1);
            // assert: IsSorted(array, pivot+1, to)
#if DEBUG
            Console.WriteLine(str + " Sorted Higher: " + ShowArray(array, pivot + 1, to));
#endif

            // provides: IsSorted(array, from, to)
        }

        public void SequentialQuickSort(T[] array)
        {
            SequentialQuickSort(array, 0, array.Length - 1, 0);
            // provides: IsSorted(array)
        }

        // -------------------------------------------------------
        // functions for checking
        public bool IsSorted(T[] array) => IsSorted(array, 0, array.Length - 2);

        private bool IsSorted(T[] array, int from, int to)
        {
            for (var i = from; i < to; i++)
            {
                if (_theCmp(array[i], array[i + 1]) == Cmp.Gt)
                {
                    throw new Exception($"Array not sorted at {i} with {array[i]} > {array[i + 1]}");
                }
            }

            return true;
        }

        // this delegate defines a predicate over the list elements; mainly for testing
        private delegate bool TestDelegate(T x);

        private static bool Forall(TestDelegate isOk, T[] array, int from, int to)
        {
            for (var i = from; i <= to; i++)
            {
                if (!isOk(array[i]))
                {
                    // throw new Exception($"Fail at {i} ");
                    return false;
                }
            }

            return true;
        }

        private bool IsPartition(T[] array, int from, int to, int pivot)
        {
            return
                Forall((x) => _theCmp(x, array[pivot]) == Cmp.Lt || _theCmp(x, array[pivot]) == Cmp.Eq, array, from,
                    pivot) &&
                Forall((x) => _theCmp(x, array[pivot]) == Cmp.Gt, array, pivot + 1, to);
        }

        public string ShowArray(T[] array, int from, int to)
        {
            var str = "";
            if (from > to)
            {
                return str;
            }

            do
            {
                str += " " + array[from].ToString();
                from++;
            } while (from <= to);

            return str;
        }

#if DEBUG
        private string Indent(int level)
        {
            var str = "";
            for (var i = 0; i < level; i++)
            {
                str += ">";
            }

            return str;
        }
#endif
    }
}
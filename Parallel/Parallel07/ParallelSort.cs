using System;
using System.Threading.Tasks;

namespace Parallel07
{
    public static class ParallelSort
    {
        private const int Threshold = 1; // threshold switching to a different sort

        private static void Swap(int[] array, int i, int j)
        {
            if (i == j) return;

            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        private static bool IsSorted(int[] array, int from, int to)
        {
            for (var i = from; i < to; i++)
            {
                if (array[i] > array[i + 1])
                {
                    // error case
                    throw new System.Exception($"Array not sorted at {i} with {array[i]} > {array[i + 1]}");
                }
            }

            return true;
        }

        private delegate bool TestDelegate(int x);

        private static bool Forall(TestDelegate is_ok, int[] array, int from, int to)
        {
            var ok = true;
            for (var i = from; i <= to; i++)
            {
                if (!is_ok(array[i]))
                {
                    return false;
                }
            }

            return ok;
        }

        private static bool IsPartition(int[] array, int from, int to, int pivot)
        {
            return
                Forall((x) => x <= array[pivot], array, from, pivot) &&
                Forall((x) => x > array[pivot], array, pivot + 1, to);
        }

        // This implements a naive bubble-sort
        private static void BubbleSort(int[] array, int from, int to)
        {
            // requires: 0 <= from <= to <= array.Length-1
            var swapped = false;

            if (from < 0 || to > array.Length - 1)
            {
                throw new System.Exception("BubbleSort: out of bounds");
            }

            if (from >= to)
            {
                return;
            }

            do
            {
                swapped = false;
                for (var i = from; i < to; i++)
                {
                    if (array[i] <= array[i + 1]) continue;
                    Swap(array, i, i + 1);
                    swapped = true;
                }
            } while (swapped);

            // provides: IsSorted(array, from, to)
        }

        private static int Partition(int[] array, int from, int to, int pivot)
        {
            // requires: 0 <= from <= pivot <= to <= array.Length-1
            // int old_from = from, old_to = to;
            var lastPivot = -1;
            var pivotVal = array[pivot];
            if (from < 0 || to > array.Length - 1)
            {
                throw new System.Exception(
                    $"Partition: indices out of bounds: from={from}, to={to}, Length={array.Length}");
            }

            while (from < to)
            {
                if (array[from] > pivotVal)
                {
                    Swap(array, from, to);
                    to--;
                }
                else
                {
                    if (array[from] == pivotVal)
                    {
                        lastPivot = from;
                    }

                    from++;
                }
            }

            if (lastPivot == -1)
            {
                if (array[from] == pivotVal)
                {
                    return from;
                }
                else
                {
                    throw new System.Exception("Partition: pivot element not found in array");
                }
            }

            if (array[from] > pivotVal)
            {
                // bring pivot element to end of lower half
                Swap(array, lastPivot, from - 1);
                return from - 1;
            }

            // done, bring pivot element to end of lower half
            Swap(array, lastPivot, @from);
            return @from;

            // provides: forall from <= i <= from. array[i]<=array[from] && 
            //           forall from+1 <= i <= to. array[i]>array[from] &&
        }

        private static string ShowArray(int[] array, int from, int to)
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

        // From: http://msdn.microsoft.com/en-us/library/ff963551.aspx
        private static void SequentialQuickSort(int[] array, int from, int to)
        {
            // requires: 0 <= from <= to <= array.Length-1
            if (to - from <= Threshold)
            {
                // InsertionSort(array, from, to);
                BubbleSort(array, from, to);
            }
            else
            {
                int pivot = from + (to - from) / 2;
                pivot = Partition(array, from, to, pivot);
                if (!IsPartition(array, from, to, pivot))
                {
                    throw new Exception($"segment from {from} to {to} (pivot {pivot}) is not a partition");
                }

                SequentialQuickSort(array, from, pivot - 1);
                // assert: IsSorted(array, from, pivot)

                SequentialQuickSort(array, pivot + 1, to);
                // assert: IsSorted(array, pivot+1, to)
            }

            // provides: IsSorted(array, from, to)
        }

        public static void SequentialQuickSort(int[] array) =>
            SequentialQuickSort(array, 0, array.Length - 1);

        // parallel divide-and-conquer with explicit threshold
        private static void ParallelQuickSort(int[] array, int from, int to, int depthRemaining)
        {
            // requires: 0 <= from <= to <= array.Length-1
            if (to - from <= Threshold)
            {
                // InsertionSort(array, from, to);
                BubbleSort(array, from, to);
            }
            else
            {
                var pivot = from + (to - from) / 2;
                pivot = Partition(array, from, to, pivot);
                if (!IsPartition(array, from, to, pivot))
                {
                    throw new System.Exception($"segment from {from} to {to} (pivot {pivot}) is not a partition");
                }

                if (depthRemaining > 0)
                {
                    Parallel.Invoke(
                        () => ParallelQuickSort(array, from, pivot - 1,
                            depthRemaining - 1),
                        () => ParallelQuickSort(array, pivot + 1, to,
                            depthRemaining - 1));
                }
                else
                {
                    ParallelQuickSort(array, from, pivot - 1, 0);
                    // assert: IsSorted(array, from, pivot)

                    ParallelQuickSort(array, pivot + 1, to, 0);
                    // assert: IsSorted(array, pivot+1, to)
                }
            }

            // provides: IsSorted(array, from, to)
        }

        // wrapper, explicit parallelism threshold
        public static void ParallelQuickSort(int[] array, int t)
        {
            ParallelQuickSort(array, 0, array.Length - 1, t);
            // provides: IsSorted(array, from, to)
        }

        // wrapper, limiting the amount of parallelism
        public static void ParallelQuickSort(int[] array)
        {
            ParallelQuickSort(array, 0, array.Length - 1,
                (int) Math.Log(Environment.ProcessorCount, 2) + 4);
        }
    }
}
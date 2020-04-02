namespace Functions
{
    using System;

    public static class Functions
    {
        public static void Main()
        {
            int[] arr = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            const int x = 0;
            const int n = 3;
            const int n1 = 5;
            const int n2 = 7;
            var n3 = 9;
            Console.WriteLine("Testing array operations on this array: " + ShowArr(arr));
            Console.WriteLine($"Get of {n}-th element = {Get(arr, n)}");
            Console.WriteLine($"Setting the {n1}-th element to {x}");

            Set(arr, n1, x);
            Console.WriteLine("Modified array: " + ShowArr(arr));
            Console.WriteLine($"SetStepping the {n2}-th element to {x}");

            SetStepBroken(arr, n2, x);
            Console.WriteLine("Modified array: " + ShowArr(arr));
            Console.WriteLine($"Index = {n2}");
            Console.WriteLine($"SetStepping the {n3}-th elemnt to {x}");

            SetStep(arr, ref n3, x);
            Console.WriteLine("Modified array: " + ShowArr(arr));
            Console.WriteLine($"Index = {n3}");
        }

        private static int Get(int[] arr, int n)
        {
            return arr[n];
        }

        private static void Set(int[] arr, int n, int x)
        {
            arr[n] = x;
        }

        private static void SetStepBroken(int[] arr, int n, int x)
        {
            arr[n] = x;
            n += 1;
        }

        private static void SetStep(int[] arr, ref int n, int x)
        {
            arr[n] = x;
            n += 1;
        }

        private static string ShowArr(int[] arr)
        {
            var s = "";
            foreach (var i in arr)
            {
                if (s != "")
                {
                    s += ',';
                }

                s += i.ToString();
            }

            return s;
        }
    }
}
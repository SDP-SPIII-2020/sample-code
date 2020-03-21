using System;

namespace Arrays
{
    // A very simple set of array functions

    class Arrays
    {
        static void Main()
        {
            int[] arr1 = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var arr2 = new int[10]; // illustrates the use of "var"

            for (var i = 0; i < arr2.Length; i++)
            {
                arr2[i] = i;
            }

            Console.WriteLine($"arr1 = {ShowArr(arr1)}");
            Console.WriteLine($"arr2 = {ShowArr(arr2)}");

            if (EqArr(arr1, arr2)) // use inline "if" instead "?:"
            {
                Console.WriteLine("Both arrays are equal!");
            }
            else
            {
                Console.WriteLine("The arrays are NOT equal!");
            }
        }

        static bool EqArr(int[] arr1, int[] arr2)
        {
            int n1 = arr1.Length, n2 = arr2.Length;
            if (n1 != n2)
            {
                return false;
            }

            for (var i = 0; i < n1; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }

        // useful for testing
        static string ShowArr(int[] arr)
        {
            string s = "";
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
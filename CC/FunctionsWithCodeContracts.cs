// -------------------------------------------------------------
// define CONTRACTS_FULL
// define DEBUG

using System;
using System.Diagnostics.Contracts;
// Examples from Lecture 3: C# Basics, adapted to use code contracts


class Functions
{
    static void Main()
    {
        int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int x = 0;
        int good_n = 3;  // OK index
        int bad_n = 15;  // illegal index
        int n1 = 7;
        int n2 = 8;
        int n3 = 9;
        System.Console.WriteLine("Testing array operations on this array: " + showArr(arr));
        System.Console.WriteLine("Get of {0}-th elemnt (out of {1}) = {2}",
	  good_n, arr.Length, Get(arr, good_n)); // OK
        System.Console.WriteLine("Get of {0}-th elemnt (out of {1}) = {2}",
	  bad_n, arr.Length, Get(arr, bad_n)); // throws an illegal index exception, unless checked by pre-condition

        System.Console.WriteLine("Setting the {0}-th elemnt to {1}", n1, x);
        Set(arr, n1, x);
        System.Console.WriteLine("Modified array: " + showArr(arr));

        System.Console.WriteLine("SetSteping the {0}-th elemnt to {1}", n2, x);
        SetStepBroken(arr, n2, x);
        System.Console.WriteLine("Modified array: " + showArr(arr));
        System.Console.WriteLine("Index = {0}", n2);
        System.Console.WriteLine("SetSteping the {0}-th elemnt to {1}", n3, x);
        SetStep(arr, ref n3, x);
        System.Console.WriteLine("Modified array: " + showArr(arr));
        System.Console.WriteLine("Index = {0}", n3);
    }

    static int Get(int[] arr, int n)
    {
        Contract.Requires(n < arr.Length);
        return arr[n];
    }

    static void Set(int[] arr, int n, int x)
    {
        Contract.Requires(n < arr.Length);
        arr[n] = x;
    }

    static void SetStepBroken(int[] arr, int n, int x)
    {
        arr[n] = x;
        n += 1;
    }

    static void SetStep(int[] arr, ref int n, int x)
    {
        arr[n] = x;
        n += 1;
    }

    static string showArr(int[] arr)
    {
        string s = "";
        foreach (int i in arr)
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

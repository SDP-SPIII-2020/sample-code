/* 
A generic sorting algorithm that uses delegates for the comparison operator
This version additionally uses generics to abstract over the data-type
This is also used later in the part on parallel programing with the TPL library.
*/

// -----------------------------------------------------------------------------
// configuration: pre-processing flags to turn on or off

// uncomment one of the lines below to en-/dis-able debugging
// #define DEBUG
#undef DEBUG

// uncomment one of the lines below to print/surpress output of sorted list
// #define PRINT
#undef PRINT

using System;
// using System.Threading.Tasks;
// using Parallel;
using System.Collections.Generic;    // for Sort
// using System.Collections.Concurrent; // for Partitioner

// -----------------------------------------------------------------------------
// sorting class

public class GenSort<T> {

  // enumeration for results of a generic comparison function
  // NB: the mapping to values is designed to conform with System.Comparison<T>
  public enum Cmp { GT=1, EQ=0, LT=-1 };
  
  // this delegate defines a predicate over the list elemnts; mainly for testing
  // see also (using System): public delegate int Comparison<in T>
  public delegate Cmp CmpDelegate(T x, T y);

  // the actual function to compare something
  public CmpDelegate the_cmp;
  
  public GenSort(CmpDelegate cmp) {
    the_cmp = cmp;
  }

  // -------------------------------------------------------
  // aux fcts

  private static void Swap(T[] array, int i, int j){
    // requires: 0 <= i,j, <= array.Length-1
    /*
    if (i<0 || i>array.Length-1 || j<0 || j>array.Length-1) {
      throw new System.Exception("Swap: indices out of bounds");
    }
    */
    if (i==j) {
      return;
    } else {
      T tmp = array[i];
      array[i] = array[j];
      array[j] = tmp;
    }
  }

  // -------------------------------------------------------
  // QuickSort
  
  private int Partition(T[] array, int from, int to, int pivot) {
    // requires: 0 <= from <= pivot <= to <= array.Length-1
#if DEBUG
    int old_from = from, old_to = to;
#endif
    int? last_pivot = null;
    T pivot_val = array[pivot];
#if DEBUG
    if (to - from < 1) {
      throw new System.Exception(String.Format("Partition: cannot partition a 1 element array (from={0}, to={1}): ", 
					       from, to, ShowArray(array, from, to)));
    }
#endif
    if (from<0 || to>array.Length-1 || pivot<from || pivot>to) {
      throw new System.Exception(String.Format("Partition: indices out of bounds: from={0}, pivot={1}, to={2}, Length={3}", 
					       from, pivot, to, array.Length));
    }
    while (from<to) {
      if (the_cmp(array[from], pivot_val) == Cmp.GT) { // using DELEGATE
	// if (array[from]>pivot_val) { // using delegate
	Swap(array, from, to);
	to--;  
      } else {
	if (the_cmp(array[from], pivot_val) == Cmp.EQ) {
	  last_pivot = from;
	}
	from++;
      }
    }
    if (!last_pivot.HasValue) {
      if (the_cmp(array[from], pivot_val) == Cmp.EQ ) {
	return from;
      } else {
	throw new System.Exception(String.Format("Partition: pivot element {0} not found", pivot_val));
      }
    }
    if (the_cmp(array[from], pivot_val) == Cmp.GT) {
      // bring pivot element to end of lower half
      Swap(array, (int)last_pivot, from-1);
      return from-1;
    } else {
      // done, bring pivot element to end of lower half
      Swap(array, (int)last_pivot, from);
      return from;
    }
    // provides: forall from <= i <= from. array[i]<=array[from] && 
    //           forall from+1 <= i <= to. array[i]>array[from] &&
  }

  private void SequentialQuickSort(T[] array, int from, int to, int level) {
   // requires: 0 <= from <= to <= array.Length-1
#if DEBUG
   string str;
   str = Indent(level);
#endif
  if (to - from < 1) {
     // a 1 elem list is sorted, per definitionem
     return;
   } else {
#if DEBUG
     Console.WriteLine(str + " Input: " + ShowArray(array, from, to));
#endif
     int pivot = from + (to - from) / 2;
     pivot = Partition(array, from, to, pivot);
#if DEBUG
     if (!IsPartition(array, from, to, pivot)) {
       throw new System.Exception(String.Format("segment from {0} to {1} (pivot {2}) is not a partition", from, to, pivot));
     }
     Console.WriteLine(str + " partitioning with pivot index {0} value {1}... ", pivot, array[pivot]);
#endif
     // recursive call on lower segment
     SequentialQuickSort(array, from, pivot - 1, level+1);
     // assert: IsSorted(array, from, pivot)
#if DEBUG
     Console.WriteLine(str + " Sorted Lower: " + ShowArray(array, from, pivot-1));
#endif
     // recursive call on upper segment
     SequentialQuickSort(array, pivot + 1, to, level+1);
     // assert: IsSorted(array, pivot+1, to)
#if DEBUG
     Console.WriteLine(str + " Sorted Higher: " + ShowArray(array, pivot+1, to));
#endif
   }
   // provides: IsSorted(array, from, to)
 }

 public void SequentialQuickSort(T[] array)
  {
    SequentialQuickSort(array, 0, array.Length-1, 0);
    // provides: IsSorted(array)
  } 

  // -------------------------------------------------------
  // functions for checking
  public bool IsSorted(T[] array) {
    return IsSorted(array, 0, array.Length-2);
  }
  public bool IsSorted(T[] array, int from, int to) {
    for (int i = from; i<to; i++) {
      if (the_cmp(array[i], array[i+1]) == Cmp.GT) { // using DELEGATE
	throw new System.Exception(String.Format("Array not sorted at {0} with {1} > {2}", i, array[i], array[i+1]));
	//return false;
      }
    }
    return true;
  }

  // this delegate defines a predicate over the list elements; mainly for testing
  private delegate bool TestDelegate(T x);
  private static bool Forall(TestDelegate is_ok, T[] array, int from, int to){
    bool ok = true;
    for(int i = from; i<=to; i++) {
      if (!is_ok(array[i])) {
	  // throw new System.Exception(String.Format("Fail at {0} ", i));
	  return false; 
	}
    }
    return ok;
  }
  private bool IsPartition(T[] array, int from, int to, int pivot) {
    return
      Forall((x) => the_cmp(x, array[pivot]) == Cmp.LT || the_cmp(x, array[pivot]) == Cmp.EQ, array, from, pivot) &&
      Forall((x) => the_cmp(x, array[pivot]) == Cmp.GT, array, pivot+1, to);
  }

  public string ShowArray(T[] array, int from, int to) {
    string str = "";
    if (from>to) { return str; } 
    do {
      str += " " + array[from].ToString();
      from++;
    } while (from<=to);
    return str;
  }

#if DEBUG  
  public string Indent(int level) {
    string str = "";
    for (int i = 0; i<level; i++) { str += ">"; }
    return str;
  }
#endif
  
}

//-----------------------------------------------------------------------------
// Test wrapper
  
public class Tester {

  // private const int Threshold = 1; // threshold switching to a different sort
  private const int Size = 1000000; // size of arrays to sort
  private const int MaxVal = 1000;  // bound on values
  private const int Iterations = 1; // number of tests to run

  public delegate int MyIntDelegate(int x, int y);
  
  // my sorting function: ascending order of integers
  public static GenSort<int>.Cmp intCmp(int x, int y) {
    if (x>y)
      return GenSort<int>.Cmp.GT;
    else if (x==y)
      return GenSort<int>.Cmp.EQ;
    else
      return GenSort<int>.Cmp.LT;
  }

  // my sorting function: descending order of integers
  public static GenSort<int>.Cmp intCmpInv(int x, int y) {
    if (x>y)
      return GenSort<int>.Cmp.LT;
    else if (x==y)
      return GenSort<int>.Cmp.EQ;
    else
      return GenSort<int>.Cmp.GT;
  }

  private static bool eqArr<T>(T[] arr1, T[] arr2) {
    int n = arr1.Length < arr2.Length ? arr1.Length : arr2.Length;
    bool ok = true;
    for (int i = 0; ok && i<n; i++) { ok&= ok && arr1[i].Equals(arr2[i]); }
    return ok && arr1.Length == arr2.Length;
  }
     
  public static void Main(string []args) {
     if (args.Length != 2) { // expect 1 arg: value to double
       System.Console.WriteLine("Usage: <prg> <v> <n> ");
       System.Console.WriteLine("v ... version (0: ascending order; 1: descending order)");
       System.Console.WriteLine("n ... list length");
       // System.Console.WriteLine("t ... threshold for generating parallelism");
     } else {    
       // int k = Convert.ToInt32(args[0]);
       int v = Convert.ToInt32(args[0]);
       int n = Convert.ToInt32(args[1]);
       // int t = Convert.ToInt32(args[2]);

       GenSort<int> theGenSort;
       GenSort<int>.CmpDelegate theCmp;
       // an instance of the sorter class, using int comparison
       GenSort<int> myGenSortAsc = new GenSort<int>(intCmp);
       // an instance of the sorter class, using int comparison
       GenSort<int> myGenSortDesc = new GenSort<int>(intCmpInv);
       
       int seed = 1701 + 13 * n ;
       int j = 0;
       for (j = 0; j < Iterations; j++) { 
	 Random rg = new Random((seed+j*7)%65535); // fix a seed for deterministic results
	 int[] arr = new int[n];
	 Console.WriteLine("Generating an array of size {0} ...", n);
	 for (int i = 0; i < n; i++) {
	   arr[i]= rg.Next() % MaxVal;
	 }
	 // copy the array, to allow in-place sorting
	 int[] arr1 = (int[])arr.Clone();
	 switch (v) { // sequential sort
	 case 0: Console.WriteLine("Sequential quick-sort, ascending order (size {0}) ...", n);
	         theGenSort = myGenSortAsc;
		 //theCmp = intCmp;
		 break;
	 case 1: Console.WriteLine("Sequential quick-sort, descending order (size {0}) ...", n);
	         theGenSort = myGenSortDesc; 
		 //theCmp = intCmpInv;
		 break;

         default: Console.WriteLine("Unknown version {0}; use 0: sequential", v);
                  continue;
	 }
	 theGenSort.SequentialQuickSort(arr);
	 /* test whether the result is Sorted */
	 try {
	   Console.WriteLine("Sorted?: {0}", theGenSort.IsSorted(arr).ToString());
#if PRINT	   
	   Console.WriteLine(theGenSort.ShowArray(arr,0, arr.Length-1));
#endif
	 } catch (Exception e) {
	   Console.WriteLine("Some test failed!!!");
	   Console.WriteLine(theGenSort.ShowArray(arr,0, arr.Length-1));
	 }
	 /* another way to test whether the result is sorted, using built-in sort */
	 // use built-in sort on arrays; Comparison fct needs int as return val, but should behave as defined!
	 Array.Sort<int>(arr1, delegate(int x, int y) { return (int)theGenSort.the_cmp(x, y); });
	 // if (arr.Equals(arr1)) // WRONG: this test for *reference* equality, not *value* equality
	 if (eqArr(arr,arr1))     // use our own impl. of value eq
	   Console.WriteLine(".. result OK");
	 else {
	   Console.WriteLine("** result WRONG");
	   Console.WriteLine("** should be " + theGenSort.ShowArray(arr1, 0, arr1.Length-1));
	 }
       }
     }
  }
}
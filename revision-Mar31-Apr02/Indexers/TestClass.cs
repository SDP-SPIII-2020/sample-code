// Lecture 6: Advanced C# Constructs: Indexers

using System;

public class ListBox {
  private string[] strings;
  private int ctr = 0;

  public ListBox (params string[] initStrs) {
    strings = new String[256];
    foreach (string s in initStrs) {
      strings[ctr++] = s;
    }
  }
  public void Add (string s) {
   if (ctr >= strings.Length) {
        // ToDo: handle overflow
   } else {
        strings[ctr++] = s;
   }
  }
  // indexer
  public string this[int index] {
    get {
      if (index <0 || index>= strings.Length) {
        // handle error case
	return "ERROR: index out of bounds";
      } else {
        return strings[index];
      }
    }
    set {
      if (index >= ctr) {
        // handle error case
      }  else {
        strings[index] = value;
      }
    }
  }

  public int GetNumEntries() { return ctr; }
}

public class Tester {
  public static void Main () {
    ListBox lbt = new ListBox("Hello", "World");
    lbt.Add("hello");
    lbt.Add("rest");

    // direct write access
    lbt[2] = "cheers";

    // direct read access
    for (int i = 0; i<lbt.GetNumEntries(); i++) {
     Console.WriteLine("lbt[{0}]: {1}", i, lbt[i]);
    }
  }
}

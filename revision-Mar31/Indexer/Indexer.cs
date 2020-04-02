using System;

namespace Indexer
{
    public class ListBox
    {
        private string[] strings;
        private int _ctr = 0;

        public ListBox(params string[] initStrs)
        {
            strings = new string[256];
            foreach (var s in initStrs)
            {
                strings[_ctr++] = s;
            }
        }

        public void Add(string s)
        {
            if (_ctr >= strings.Length)
            {
                // ToDo: handle overflow
            }
            else
            {
                strings[_ctr++] = s;
            }
        }

        // indexer
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= strings.Length)
                {
                    // handle error case
                    return "ERROR: index out of bounds";
                }
                else
                {
                    return strings[index];
                }
            }
            set
            {
                if (index >= _ctr)
                {
                    // handle error case
                }
                else
                {
                    strings[index] = value;
                }
            }
        }

        public int GetNumEntries()
        {
            return _ctr;
        }
    }

    public static class Tester
    {
        public static void Main()
        {
            var lbt = new ListBox("Hello", "World");
            lbt.Add("hello");
            lbt.Add("rest");

            // direct write access
            lbt[2] = "cheers";

            // direct read access
            for (var i = 0; i < lbt.GetNumEntries(); i++)
            {
                Console.WriteLine($"lbt[{i}]: {lbt[i]}");
            }
        }
    }
}
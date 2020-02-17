using System;

namespace IndexerExample
{
    class Program
    {
        static void Main(string[] args)
        {
           var s = new StringData();
           s[0] = "Some string";
           s[1] = "Another string";
           s[9] = "foo";

           for (var i=0; i < s.Size; i++)
           {
               Console.WriteLine(s[i]);
           }
        }
    }

    class StringData
    {
        private string[] strArr = new string[10];
        
        public int Size => strArr.Length;

        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= strArr.Length)
                {
                    throw new IndexOutOfRangeException("some message - get");
                }

                return strArr[index];
            }
            set
            {
                if (index < 0 || index >= strArr.Length)
                {
                    throw new IndexOutOfRangeException("some message - set");
                }

                strArr[Size-index-1] = value;
            }
        }
    }
}
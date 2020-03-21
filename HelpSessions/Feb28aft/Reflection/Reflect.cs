using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Reflection
{
    class Reflect
    {
        static void Main(string[] args)
        {
            var dict = Init();
            string str = default(string);
            do
            {
                Console.Write("Name of class: ");
                str = Console.ReadLine();
                str = Lookup(str,dict);
                var t = Type.GetType(str);
                if (t == null)
                {
                    Console.WriteLine($"Sorry couldn't find class {str}");
                }
                else
                {
                    Console.WriteLine(t);
                    var obj = Activator.CreateInstance(t);
                    Console.WriteLine(obj);
                }
            } while (!str.Equals("STOP"));
        }

        static Dictionary<string, string> Init() //<T1,T2>()
        {
            var dict = new Dictionary<string, string>();
            //var f = new Dictionary<string,Func<T1,T2>>();
            //f["A"] = Func<int,int> (x) => x;
            dict["A"] = "Reflection.AImpl";
            dict["B"] = "Reflection.BImpl";
            return dict;
        }
        static string Lookup(string str, Dictionary<string,string> dict) => dict[str];
    }

    interface IThing
    {
    }

    class AImpl: IThing
    {
        public override string ToString() => $"@ {this.GetType().ToString()}";
    }

    class BImpl: IThing
    {
        public override string ToString() => this.GetType().ToString();
    }
}
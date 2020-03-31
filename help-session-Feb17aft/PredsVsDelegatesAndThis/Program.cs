using System;

namespace PredsVsDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> thing = s => s.Equals(s.ToUpper());
            Predicate<string> delegateThing = delegate(string s) { return s.Equals(s.ToUpper()); };
            
            var str = "HELLO";
            WriteDecision(str, (string s) => s.Equals(s.ToUpper()));
            WriteDecision(str, IsLowerCase);
            str.Remove('a').IsLowerCase();
            //IsLowerCase(str.Remove('a'));
        }

        static void WriteDecision(string str, Predicate<string> decision) => 
            // Predicate<string> equiv to Func<string,bool>
            Console.WriteLine(decision(str));
        
        //static bool IsUpperCase(string str) => str.Equals(str.ToUpper());

        static bool IsLowerCase(string str) => str.Equals(str.ToLower());
    }
}
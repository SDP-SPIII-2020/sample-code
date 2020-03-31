using System;

namespace linkedlists
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var l = new List<int>();
            l = l.Add(3);
            l = l.Add(4);
            l = l.Add(5);
            Console.WriteLine(l);
            var lHead = l.Head;
            var lTail = l.Tail;
            Console.WriteLine($"Head: {lHead}, Tail: {lTail}");
            l.ForEach(Console.WriteLine);
        }
    }
}
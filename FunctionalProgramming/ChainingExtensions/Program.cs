using System;
using System.Text;

namespace ChainingExtensions
{
    public static class Extensions
    {
        public static StringBuilder AppendWhen(this StringBuilder sb, string value, bool predicate) =>
            predicate ? sb.Append(value) : sb;
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            // Extends the StringBuilder class to accept a predicate
            string htmlButton = new StringBuilder()
                .Append("<button")
                .AppendWhen(" disabled", false)
                .Append(">Click me</button>")
                .ToString();
            Console.WriteLine(htmlButton);
        }
    }
}
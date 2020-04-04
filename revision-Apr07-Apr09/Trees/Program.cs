using System;
using System.Linq;

namespace Dependencies
{
    public static class Program
    {
        private static int Inc(int i) => i + 1;

        public static void Main(string[] args)
        {
            var t = new Tree<int>();
            var rand = new Random();
            var arrFix = System.Enum.GetValues(Tree<int>.Fixity.Infix.GetType());
            var values = Enumerable.Range(1, 10).ToArray();
            var lst = values.ToList().OrderBy(i => rand.Next(101)).ToList();
            
            {
                // build tree ...
                // ToDo: use exceptions to catch non-int values
                foreach (var i in lst)
                {
                    Console.WriteLine($"inserting {i} ...");
                    t.Insert(i);
                }

                // test Find ...
                Console.WriteLine($"Having added all arguments into the tree it looks like this:\n{t}");
                int[] xs = {0, 5, 7, 9, 99};
                foreach (var x in xs)
                {
                    Console.WriteLine($"Finding value {x} in tree: {t.Find(x)}");
                }

                // test Insert ... 
                var z = 5;
                Console.WriteLine($"inserting {z} ...");
                t.Insert(5);
                Console.WriteLine($"After inserting {z} the new tree looks like this:\n{t}");
                foreach (var x in xs)
                {
                    Console.WriteLine($"Finding value {x} in tree: {t.Find(x)}");
                }

                // test generic dfs ... 
                Console.WriteLine(
                    "Testing generic dfs with infix order of nodes, producing a sorted list of values ...");
                foreach (var elem in t.Dfs())
                {
                    Console.Write(" " + elem);
                }

                // test delegates ... 
                Console.WriteLine("\nTesting mapTree on above int tree, increasing each element by 1 ...");
                var f = new Node<int>.TreeMapperDelegate(Inc);
                t.Root.MapTree(f);
                Console.WriteLine($"{t}");
                Console.WriteLine("Testing mapTree on above int tree, doubling each element ...");
                t.Root.MapTree(n => n + 1);
                Console.WriteLine($"{t}");
                // same thing again, shorter
                Console.WriteLine(
                    "Again, testing mapTree on above int tree, increasing each element by 1 (using lambda expression)...");
                t.Root.MapTree(j => j + 1);
                Console.WriteLine("{t}");

                // use different iterators to print the tree
                foreach (Tree<int>.Fixity fix in arrFix)
                {
                    try
                    {
                        t.Print(fix); // eg.: t.print(Tree<int>.Fixity.Infix);
                    }
                    catch (TreeException e)
                    {
                        Console.WriteLine($"print failed, using a {fix} traversal");
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
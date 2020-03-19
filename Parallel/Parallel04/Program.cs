// Extending the Binary Search Tree examples
// to parallelism, using a divide-and-conquer paradigm.

using System;
using System.Collections;

namespace Parallel04
{
    public static class Program
    {
        private static int Inc(int i) => i + 1;

        public static void Main(string[] args)
        {
            int i;
            var t = new Tree<int>();

            if (args.Length < 1)
            {
                Console.WriteLine("Provide int values to add to the tree on the command line ...");
            }
            else
            {
                // build tree ...
                // ToDo: use exceptions to catch non-int values
                foreach (var s in args)
                {
                    i = Convert.ToInt32(s); // int.Parse(s);
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

                // test delegates ... 
                Console.WriteLine("Testing MapTree on above int tree, increasing each element by 1 ...");
                Node<int>.TreeMapperDelegate f = new Node<int>.TreeMapperDelegate(Program.Inc);
                t.Root.MapTree(f);
                Console.WriteLine("{0}", t.ToString());

                // same thing again, shorter
                Console.WriteLine(
                    "Again, testing MapTree on above int tree, increasing each element by 1 (using lambda expression)...");
                t.Root.MapTree(new Node<int>.TreeMapperDelegate((int j) => j + 1));
                Console.WriteLine("{0}", t.ToString());

                // and yet again, now in parallel
                Console.WriteLine(
                    "Again, but now in parallel, increasing each element by 1 (using lambda expression)...");
                t.Root.ParMapTree(new Node<int>.TreeMapperDelegate((int j) => j + 1));
                Console.WriteLine(t);

                // use different iterators to print the tree
                var arrFix = Enum.GetValues(Tree<int>.Fixity.Infix.GetType());
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
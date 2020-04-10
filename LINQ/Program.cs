#define FIVE

using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> booklist = new List<Book>
            {
                new Book
                {
                    Title = "Learning C#", Author = "Jesse Liberty", Publisher = "O’Reilly", Year = 2008
                },
                new Book
                {
                    Title = "Programming C#", Author = "Jesse Liberty", Publisher = "O’Reilly", Year = 2008
                },
                new Book
                {
                    Title = "Programming PHP", Author = "Rasmus Lerdorf, Kevin Tatroe", Publisher = "O’Reilly",
                    Year = 2006
                }
            };

            #region Imperative

#if ONE
            foreach (Book b in booklist)
            {
                if (b.Author == "Jesse Liberty")
                {
                    Console.WriteLine(b.Title + " by " + b.Author);
                }
            }

            Console.WriteLine();
#endif

            #endregion

            #region LINQ

#if TWO
            IEnumerable<Book> resultsAuthor =
                from b in booklist
                where b.Author == "Jesse Liberty"
                select b;
            Console.WriteLine("LINQ query: find by author ..."); // process the result
            foreach (Book r in resultsAuthor)
            {
                Console.WriteLine(r.Title + " by " + r.Author);
            }

            Console.WriteLine();
#endif

            #endregion

            #region Use of anonymous type

#if THREE
            // NB: this needs to infer the type (anonymous!)
            var resultsAuthor1 =
                from b in booklist
                where b.Author == "Jesse Liberty"
                // NB: anonymous type here!
                select new {b.Title, b.Author};
            // process the result

            foreach (var r in resultsAuthor1)
            {
                Console.WriteLine(r.Title + " by " + r.Author);
            }
            Console.WriteLine();
#endif

            #endregion

            #region lambda expression here

#if FOUR
            var resultsAuthor2 =
                booklist.Where(bookEval => bookEval.Author == "Jesse Liberty");

            // process the result
            foreach (var r in resultsAuthor2)
            {
                Console.WriteLine(r.Title + " by " + r.Author);
            }

            Console.WriteLine();
#endif

            #endregion

            #region We can sort the result by author

#if FIVE
            var resultsAuthor3 =
                from b in booklist
                orderby b.Author
                // NB: anonymous type here!
                select new {b.Title, b.Author};

            Console.WriteLine("LINQ query: ordered by author ...");

            // process the result
            foreach (var r in resultsAuthor3)
            {
                Console.WriteLine(r.Title + " by " + r.Author);
            }
#endif

            #endregion
        }
    }

    internal class Book
    {
        internal string Title { get; set; }
        internal string Author { get; set; }
        internal string Publisher { get; set; }
        internal int Year { get; set; }
    }
}
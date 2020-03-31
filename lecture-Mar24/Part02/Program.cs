using System;
using System.Collections;
using System.Collections.Generic;

namespace Part02
{
    public static class Program
    {
        public static void Main()
        {
            //string connString = "myDatabase";
            
            // var conn = SqlConnection(connString);
            // conn.Open();
            // //...
            // conn.Close();
            // conn.Dispose();

            // using (var conn = SqlConnection(connString))
            // {
            //     conn.Open();
            //     //...
            // }
        }
    }

    public static class ExtClass
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> ts, Func<T,bool> predicate) 
        {
            foreach (T t in ts)
            {
                if (predicate(t))
                {
                    yield return t;
                }
            }
        }
    }
}
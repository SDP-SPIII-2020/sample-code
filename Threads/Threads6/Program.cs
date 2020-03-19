// From LinkedIn Learning course: From the course: Async Programming in C#
//     https://www.linkedin.com/learning/async-programming-in-c-sharp?u=2374954
// and from
//     https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/using-async-for-file-access

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Threads6
{
    public class AsyncFiles
    {
        private static async Task ProcessRead(string filePath)
        {
            //filePath = @"temp.txt";

            Console.WriteLine("ProcessRead: Begin");

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
            }
            else
            {
                try
                {
                    var text = await ReadTextAsync(filePath);
                    Console.WriteLine(text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("ProcessRead: End");
        }

        private static async Task<string> ReadTextAsync(string filePath)
        {
            await using var sourceStream = new FileStream(filePath, FileMode.Open, FileAccess.Read,
                FileShare.Read, bufferSize: 4096, useAsync: true);
            var sb = new StringBuilder();

            var buffer = new byte[0x1000];
            int numRead;
            while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                var text = Encoding.Unicode.GetString(buffer, 0, numRead);
                sb.Append(text);
            }

            Thread.Sleep(5000);

            return sb.ToString();
        }

        public async Task DoIt(params string[] strings)
        {
            var tasks = strings.Select(ProcessRead).ToList();
            await Task.WhenAll(tasks);
        }
    }

    public static class Tester
    {
        public static async Task Main()
        {
            var afs = new AsyncFiles();
            Console.WriteLine("Main: before ProcessRead()");
            await afs.DoIt("temp.txt", "tmp.txt");
            Console.WriteLine("Main: after ProcessRead()");
        }
    }
}
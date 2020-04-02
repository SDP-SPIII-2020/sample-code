// -----------------------------------------------------------------------------
// Example of multi-threading, passing the value retrieved by one thread to the other thread.
// The operations are: (1) reading from a file (2) displaying the file contents
// -----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Threading;

namespace Threads3
{
    // A class for testing concurrent read and display threads
    public class Test
    {
        // booleans, indicating whether data has arrived; needed for synchronisation
        private readonly bool _okFileName = false;
        private bool _okContents = false;
        private readonly object _mainLock = new { }; // any non-null object will do as lock

        private readonly FileData _currentFileData; // handle on the context for file ops

        private static readonly LinkedList<FileData>
            AllFileData = new LinkedList<FileData>(); // list of all file contexts

        // define an exception, triggered by the balance being too low
        public class NoFile : Exception
        {
            public NoFile(string msg) : base(msg)
            {
            }
        }

        // constructor; needs the filename to read from/display
        public Test(string filename)
        {
            _currentFileData = new FileData(filename);
            _okFileName = true;
            AllFileData.AddLast(_currentFileData);
        }

        // requires: File.Exists(filename)
        // summary: retrieve the contents for the current file
        private void GetFContents()
        {
            while (!_okFileName)
            {
                // Thread.Sleep(1);  // busy wait; better: use Wait and Pulse from within getFilenName
                Monitor.Wait(_mainLock);
            }

            Console.WriteLine("<{0}> we have the name of the file ... ", Thread.CurrentThread.Name);

            // assert: not (null filename)
            // lock (mainLock) {

            var inValue = "";
            try
            {
                Monitor.Enter(_mainLock); // enter critical region

                Console.WriteLine("<{0}> reading file contents ... ", Thread.CurrentThread.Name);

                using var sr = new StreamReader(_currentFileData.FileName);
                // std iteration over the contents of a file
                while ((inValue = sr.ReadLine()) != null) // read line-by-line
                    _currentFileData.Contents = inValue + "\n";

                _okContents = true;
                Monitor.Pulse(_mainLock);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Monitor.Exit(_mainLock);
            }
        }

        // summary: show the previously retrieved contents for the current file
        private void DisplayContents()
        {
            Monitor.Enter(_mainLock);
            while (!_okContents)
            {
                Console.WriteLine($"<{Thread.CurrentThread.Name}> Waiting ...");
                Monitor.Wait(_mainLock);
            }

            Console.WriteLine($"<{Thread.CurrentThread.Name}> we have the contents of the file ... ");
            Console.WriteLine($"<{Thread.CurrentThread.Name}> Continuing ...");
            Console.Write("-------------------------------------------------------");
            Console.Write($" <{Thread.CurrentThread.Name}>");
            Console.Write($"(Contents); of file {_currentFileData.FileName} ({FileData.Counter} files in total):");
            Console.WriteLine(_currentFileData.Contents);
            Console.WriteLine(
                "<{_currentFileData.FileName}> end of file ------------------------------------------------------- ");
            Monitor.Exit(_mainLock);
        }

        public void RunTest()
        {
            // kicks-off 2 threads: one for reading the file contents, the other to display it
            var getT = new Thread(new ThreadStart(GetFContents))
            {
                Name = "getContentsThread_for_file_" + _currentFileData.FileName
            };
            var displayT = new Thread(new ThreadStart(DisplayContents))
            {
                Name = "displayContents_for_file_" + _currentFileData.FileName
            };
            //getFN.Start();
            getT.Start();
            displayT.Start();
            //getFN.Join();
            getT.Join();
            displayT.Join();
            System.Console.WriteLine($"<{Thread.CurrentThread.Name}> thread terminates.");
        }
    }
}
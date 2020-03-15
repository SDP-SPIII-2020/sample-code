namespace Threads
{
    // For a change I'll put the "using" statement inside the namespace
    using System;
    using System.Threading;
    using System.ComponentModel;

    public static class Program
    {
        private static BackgroundWorker _bw;

        public static void Main()
        {
            _bw = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _bw.DoWork += DoWork; // work to complete
            _bw.ProgressChanged += ProgressChanged; // what happens when the status changes
            _bw.RunWorkerCompleted += RunWorkerCompleted; // finished

            _bw.RunWorkerAsync("Hello to worker");

            Console.WriteLine("Press Enter in the next 5 seconds to cancel");
            Console.ReadLine();
            if (_bw.IsBusy) _bw.CancelAsync(); // kill the worker
            // Console.ReadLine(); // only required if your terminal session would close
        }

        private static void DoWork(object sender, DoWorkEventArgs e)
        {
            for (var i = 0; i <= 100; i += 20)
            {
                if (_bw.CancellationPending) // we've been killed so we just need to tidy up
                {
                    e.Cancel = true;
                    return;
                }

                _bw.ReportProgress(i); // let people know how it is going - raises "ProgressChanged"
                Thread.Sleep(1000); 
                // Just for the demo... don't go sleeping for real in pooled threads!
            }

            e.Result = 123; // This gets passed to RunWorkerCompleted as the returned result
        }

        static void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                Console.WriteLine("You canceled!");
            else if (e.Error != null)
                Console.WriteLine("Worker exception: " + e.Error);
            else
                Console.WriteLine("Complete: " + e.Result); // from DoWork
        }

        static void ProgressChanged(object sender, ProgressChangedEventArgs e) =>
            Console.WriteLine($"Reached {e.ProgressPercentage} %");
    }
}
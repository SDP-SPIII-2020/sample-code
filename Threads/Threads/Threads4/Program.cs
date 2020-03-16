namespace Threads4
{
    // just to show the "using" can be within a namespace
    using System;
    using System.Threading;
    using System.ComponentModel;

    public static class Program
    {
        private static BackgroundWorker _bw; // just the one Threads4
        private const int Count = 100;
        private const int Increment = 20;
        private const int Delay = 1000;

        public static void Main()
        {
            _bw = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _bw.DoWork += DoWork;
            _bw.ProgressChanged += ProgressChanged;
            _bw.RunWorkerCompleted += RunWorkerCompleted;

            _bw.RunWorkerAsync("Hello to worker");

            Console.WriteLine("Press Enter in the next 5 seconds to cancel");
            Console.ReadLine();
            if (_bw.IsBusy) _bw.CancelAsync();
            // Console.ReadLine(); // only if you are using a terminal window that closes automatically 
        }

        private static void DoWork(object sender, DoWorkEventArgs e)
        {
            for (var i = 0; i <= Count; i += Increment)
            {
                if (_bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                _bw.ReportProgress(i);
                Thread.Sleep(Delay);
                // Just for the demo... do not sleep for real in pooled threads!
            }

            e.Result = 123; // This gets passed to RunWorkerCompleted
        }

        private static void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                Console.WriteLine("You cancelled the run!");
            else if (e.Error != null)
                Console.WriteLine($"Worker exception: {e.Error}");
            else
                Console.WriteLine($"Completed: {e.Result}"); // from DoWork
        }

        private static void ProgressChanged(object sender, ProgressChangedEventArgs e) =>
            Console.WriteLine($"Reached {e.ProgressPercentage}%");
    }
}
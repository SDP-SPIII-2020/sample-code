using System;

namespace Delegates1
{
    public class MediaStorage
    {
        // declare a delegate, ie. the type of the method
        public delegate int PlayMedia();

        // this is a higher-order function, ie. it uses a delegate
        public void ReportResult(PlayMedia playerDelegate)
        {
            Console.WriteLine(playerDelegate() == 0 ? "Media played successfully" : "Error in playing media.");
        }
    }
}
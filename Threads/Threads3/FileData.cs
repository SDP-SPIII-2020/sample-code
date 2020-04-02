using System.Collections.Generic;

namespace Threads3
{
    public class FileData
    {
        // This class holds the context for one file read operation contents of the data that arrived
        public static int Counter { set; get; }

        public string FileName { get; set; }

        private string _filecontent = null;

        public string Contents
        {
            get => _filecontent;
            set => _filecontent += value;
        }

        // constructor
        public FileData(string filename)
        {
            FileName = filename;
            Counter++;
        }
    }
}
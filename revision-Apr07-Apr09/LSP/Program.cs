using System;
using System.Collections.Generic;

namespace LSP
{
    public class File
    {
        public string Path { get; set; }
        public string Type { get; set; }

        public void Load()
        {
        }

        public void Save()
        {
        }
    }

    public class ReadOnlyFile : File
    {
        public void Load()
        {
        }
        public void Save()
        {
            throw new InvalidOperationException();
        }
        
    }

    public class FileManager
    {
        private List<File> lstFiles { get; set; }

        public void LoadFiles()
        {
            foreach (var file in lstFiles)
            {
                file.Load();
            }
        }

        public void SaveFiles()
        {
            foreach (var file in lstFiles)
            {
                if (! (file is ReadOnlyFile)) // OOPS
                {
                    file.Save();
                }
            }
        }
    }


    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
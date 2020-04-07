using System;
using System.Collections.Generic;

namespace LSP_revised
{
    public interface IReadableFile
    {
        public void Load();
    }

    public interface IWritableFile
    {
        public void Save();
    }

    public class ReadOnlyFile : IReadableFile
    {
        public void Load()
        {
            // does something
        }
    }

    public class File : IReadableFile, IWritableFile
    {
        public void Load()
        {
            // does something
        }

        public void Save()
        {
            // does something
        }
    }


    public class FileManager
    {
        public void LoadFiles(List<IReadableFile> lstFiles)
        {
            foreach (var file in lstFiles)
            {
                file.Load();
            }
        }

        public void SaveFiles(List<IWritableFile> lstFiles)
        {
            foreach (var file in lstFiles)
            {
                file.Save();
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
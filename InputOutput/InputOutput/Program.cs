using System;
using System.IO;
using System.Text;

namespace InputOutput
{
    class Program
    {
        private const string Filename = "csharpfile.txt";

        static void Main(string[] args)
        {
            FileStreamExample();
            StreamExample();
            TextExample();
            BinaryExample();
        }

        // FileStream Class 
        static void FileStreamExample()
        {
            // create a file
            var fs = new FileStream(Filename, FileMode.Create);
            fs.Close();
            Console.WriteLine($"File has been created and the Path is '{Filename}'");

            // open the file and write some text to it
            fs = new FileStream(Filename, FileMode.Append);
            byte[] bdata = Encoding.Default.GetBytes("Hello File Handling!");
            fs.Write(bdata, 0, bdata.Length);
            fs.Close();
            Console.WriteLine("Successfully saved file with data : Hello File Handling!");

            // read data
            string data;
            var fsSource = new FileStream(Filename, FileMode.Open, FileAccess.Read);
            using (var sr = new StreamReader(fsSource))
            {
                data = sr.ReadToEnd();
            }

            Console.WriteLine(data);
        }

        // StreamWriter Class
        static void StreamExample()
        {
            using (var writer = new StreamWriter(Filename))
            {
                writer.Write("Hello");
                writer.WriteLine("Hello StreamWriter Class");
                writer.WriteLine("How are you!");
            }

            Console.WriteLine("Data Saved Successfully!");

            // Write data

            int a, b, result;
            a = 5;
            b = 10;
            result = a + b;

            using (var writer = new StreamWriter(Filename))
            {
                writer.Write("Sum of {0} + {1} = {2}", a, b, result);
            }

            Console.WriteLine("Saved");

            //Write data to text file
            using (var writer = new StreamWriter(Filename))
            {
                writer.WriteLine("This shows how to use the StreamReader Class");
                writer.WriteLine("Success!");
            }

            //Reading text file using StreamReader Class            
            using var reader = new StreamReader(Filename);
            Console.WriteLine(reader.ReadToEnd());
        }

        // TextWriter and TextReader
        static void TextExample()
        {
            using (TextWriter writer = File.CreateText(Filename))
            {
                writer.WriteLine("Hello TextWriter!");
                writer.WriteLine("File Handling");
            }

            Console.WriteLine("Entry stored successful!");

            //Read One Line
            using (TextReader tr = File.OpenText(Filename))
            {
                Console.WriteLine(tr.ReadLine());
            }

            //Read 4 Characters
            using (TextReader tr = File.OpenText(Filename))
            {
                var ch = new char[4];
                tr.ReadBlock(ch, 0, 4);
                Console.WriteLine(ch);
            }

            //Read file
            using (TextReader tr = File.OpenText(Filename))
            {
                Console.WriteLine(tr.ReadToEnd());
            }
        }

        // BinaryWriter and BinaryReader

        static void BinaryExample()
        {
            using (var writer = new BinaryWriter(File.Open(Filename, FileMode.Create)))
            {
                //Write to Log file
                writer.Write("0x80234400");
                writer.Write("Windows Has Stopped Working!!!!");
                writer.Write(true);
            }

            Console.WriteLine("Binary File Created!");

            using var reader = new BinaryReader(File.Open(Filename, FileMode.Open));
            Console.WriteLine("Error Code : " + reader.ReadString());
            Console.WriteLine("Message : " + reader.ReadString());
            Console.WriteLine("Restart Explorer : " + reader.ReadBoolean());
        }
    }
}
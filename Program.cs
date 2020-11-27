using System;
using System.IO;
using System.Text;
namespace _26112020
{
    class TestFileStream
    {
        public static void SaveFile(string fname = "temp.bin")
        {
            //FileStream stream = new FileStream(fname,
            //    FileMode.Create,
            //    FileAccess.Write,
            //    FileShare.None
            //    );
            //string text = "Несе Галя воду Іван IT STEP";
            //byte[] arr = Encoding.Unicode.GetBytes(text);
            //byte[] BOM = {0xFF, 0xFE};
            //stream.Write(BOM);
            //stream.Write(arr);//stream.Write(arr,0, arr.Length);
            //stream.Close();
            using (FileStream stream = new FileStream(fname, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                string text = "Несе Галя воду Іван IT STEP";
                byte[] arr = Encoding.Unicode.GetBytes(text);
                byte[] BOM = { 0xFF, 0xFE };
                stream.Write(BOM);
                stream.Write(arr);//stream.Write(arr,0, arr.Length);
                                  // stream.Dispose();
            }
            Console.WriteLine($"File {fname} saved");
        }
        public static void LoadFile(string fname = "temp.bin")
        {
            string text = "";
            using (FileStream stream = new FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] arr = new byte[stream.Length - 2];
                // Console.WriteLine("Position->" +stream.Position);
                // stream.Read(arr,0,2);
                //stream.Seek(2, SeekOrigin.Begin);
                stream.Position = 2;
                // Console.WriteLine("Position->" + stream.Position);
                stream.Read(arr);
                //  Console.WriteLine("Position->" + stream.Position);
                text = Encoding.Unicode.GetString(arr);
            }
            Console.WriteLine($"TEXT: {text} ");
            Console.WriteLine($"File {fname} loaded");

        }
    }
    class TestStreamWriter
    {
        public static void SaveFile(string fileName = "temp.txt")
        {
            using (StreamWriter stream = new StreamWriter(fileName, true, Encoding.Unicode))
            {
                stream.WriteLine("Несе Галя воду коромисло гнеться");
                stream.WriteLine(1231354);
                stream.WriteLine(2.3564);
                stream.WriteLine(5555555);
            }
            Console.WriteLine($"File {fileName} saved");
        }
        public static void LoadFile(string fileName = "temp.txt")
        {
            using (StreamReader stream = new StreamReader(fileName, Encoding.Unicode))
            {
                string text = stream.ReadLine();
                Console.WriteLine($"text {text} ");
                Console.WriteLine($"stream.EndOfStream: {stream.EndOfStream} ");
                Console.WriteLine($"Peek: {(char)stream.Peek()} ");
                Console.WriteLine($"Read: {(char)stream.Read()} ");
                Console.WriteLine($"Peek: {(char)stream.Peek()} ");
                char[] mas = new Char[4];
                stream.ReadBlock(mas, 0, 4);
                Console.WriteLine($"mas: {new string(mas)} ");
                Console.WriteLine($"text {stream.ReadToEnd()} ");
            }
            Console.WriteLine($"File {fileName} loaded");
        }
        public static void LoadFileFS(string fileName = "temp.txt")
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                fs.Position = 50;
                using (StreamReader stream = new StreamReader(fs, Encoding.Unicode))
                {
                    string text = stream.ReadLine();
                    Console.WriteLine($"text {text} ");
                    Console.WriteLine($"stream.EndOfStream: {stream.EndOfStream} ");
                    Console.WriteLine($"Peek: {(char)stream.Peek()} ");
                    Console.WriteLine($"Read: {(char)stream.Read()} ");
                    Console.WriteLine($"Peek: {(char)stream.Peek()} ");
                    char[] mas = new Char[4];
                    stream.ReadBlock(mas, 0, 4);
                    Console.WriteLine($"mas: {new string(mas)} ");
                    Console.WriteLine($"text {stream.ReadToEnd()} ");
                }
            }
            Console.WriteLine($"File {fileName} loaded");
        }

        public static void SaveFileFS(string fileName = "temp.txt")
        {
            using FileStream fs = new FileStream(fileName, FileMode.Create);
            using (StreamWriter stream = new StreamWriter(fs, Encoding.Unicode))
            {
                stream.WriteLine("Несе Галя воду коромисло гнеться");
                stream.WriteLine(1231354);
                stream.WriteLine(2.3564);
                stream.WriteLine(5555555);
            }
            Console.WriteLine($"File {fileName} saved");
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            try
            {
                Console.WriteLine("Hello World!");
                //TestFileStream.SaveFile("fs.bin");
                //TestFileStream.LoadFile("fs.bin");
                // TestStreamWriter.SaveFile("strwr.txt");
                //TestStreamWriter.SaveFileFS("strwrFS.txt");
                // TestStreamWriter.LoadFile("strwr.txt");
                TestStreamWriter.LoadFileFS("strwr.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
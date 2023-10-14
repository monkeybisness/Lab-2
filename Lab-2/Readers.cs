using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Reader
    {
        public uint Id;

        public string FullName;

        public uint ReaderTicket;

        public Dictionary<uint, DateTime> DateCapture;

        public Dictionary<uint, DateTime> DateReturn;
    }
    struct ReaderData
    {
        public ReaderData() { }

        static StreamReader data = new StreamReader(@"C:\Users\User\source\repos\Lab-2\Lab-2\Readers.csv");

        public static string[][] fileReaders = new string[File.ReadAllLines(@"C:\Users\User\source\repos\Lab-2\Lab-2\Readers.csv").Length][];

        public static string[][] RecordTheFile(string[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = data.ReadLine().Split(';');
            }
            return arr;
        }

        public static void CheckFile()
        {
            RecordTheFile(fileReaders);
            for (int i = 1;i < fileReaders.Length - 2; i++)
            {
                if (fileReaders[0].Length < fileReaders[i].Length)
                {
                    Console.WriteLine("Данных больше ,чем столбцов в таблице Readers.");
                    Environment.Exit(0);
                }
            }
            for (int i = 1;i < fileReaders.Length - 1; i++)
            {
                if (Int32.TryParse(fileReaders[i][0], out int valueOne) == false)
                {
                    Console.WriteLine($"Тип данных {fileReaders[i][0]} не совпал с типом 1 столбца Readers.");
                    Environment.Exit(0);
                }
                else if (Int32.TryParse(fileReaders[i][2], out int valueTwo) == false)
                {
                    Console.WriteLine($"Тип данных {fileReaders[i][2]} не совпал с типом 3 столбца Readers.");
                    Environment.Exit(0);
                }
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Book
    {
        public uint Id;

        public string Author;

        public string Title;

        public uint PublicationYear;

        public uint CabinetNumber;

        public uint ShelfNumber;

    }
    struct BookData
    {
        public BookData() { }

        static StreamReader data = new StreamReader(@"C:\Users\User\source\repos\Lab-2\Lab-2\Books.csv");

        public static string[][] fileBooks = new string[File.ReadAllLines(@"C:\Users\User\source\repos\Lab-2\Lab-2\Books.csv").Length][];

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
            RecordTheFile(fileBooks);
            for (int i = 0; i < fileBooks.Length - 1; i++)
            {
                if (fileBooks[0].Length < fileBooks[i].Length)
                {
                    Console.WriteLine("Данных больше ,чем столбцов в таблице Books.");
                    Environment.Exit(0);
                }
            }
            for (int i = 1; i < fileBooks.Length - 1; i++)
            {
                if (Int32.TryParse(fileBooks[i][0], out int valueOne) == false)
                {
                    Console.WriteLine($"Тип данных {fileBooks[i][0]} не совпал с типом 1 столбца Books.");
                    Environment.Exit(0);
                }
                for (int j = 3; j < fileBooks[i].Length; j++)
                {
                    if (Int32.TryParse(fileBooks[i][j], out int valueTwo) == false)
                    {
                        Console.WriteLine($"Тип данных {fileBooks[i][j]} не совпал с типом {j + 1}-го столбца Books.");
                        Environment.Exit(0);
                    }
                }
            }
        }
    }

}

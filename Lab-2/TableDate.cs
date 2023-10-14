using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    struct TableData
    {
        public TableData() { }

        static StreamReader data = new StreamReader(@"C:\Users\User\source\repos\Lab-2\Lab-2\TableDate.csv");

        public static string[][] fileTableDate = new string[File.ReadAllLines(@"C:\Users\User\source\repos\Lab-2\Lab-2\TableDate.csv").Length][];

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
            RecordTheFile(fileTableDate);
            for (int i = 1; i < fileTableDate.Length - 1; i++)
            {
                if (fileTableDate[0].Length < fileTableDate[i].Length)
                {
                    Console.WriteLine("Данных больше ,чем столбцов в таблице TableDate.");
                    Environment.Exit(0);
                }
            }
            for(int j = 1; j < fileTableDate.Length -1;  j++)
            {
                for (int i = 1; i <= 1; i++)
                {
                    if (Int32.TryParse(fileTableDate[j][i], out int valueOne) == false)
                    {
                        Console.WriteLine($"Тип данных {fileTableDate[j][i]} не совпал с типом {i + 1} столбца TableDate.");
                        Environment.Exit(0);
                    }
                }
                for(int i = 2; i < fileTableDate[j].Length; i++)
                {
                    if (DateTime.TryParse(fileTableDate[j][i], out DateTime valueTwo) == false)
                    {
                        Console.WriteLine($"Тип данных {fileTableDate[j][i]} не совпал с типом {i + 1} столбца TableDate.");
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}

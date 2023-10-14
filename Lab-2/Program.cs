using System.Globalization;

namespace Lab
{
    class Programm
    {
        void Initialize()
        {
            BookData.CheckFile();

            ReaderData.CheckFile();

            TableData.CheckFile();

            List<Reader> readers = new List<Reader>();
            for (int j = 1; j <= ReaderData.fileReaders.Length - 1; j++)
            {
                if (TableData.fileTableDate[j].Length < 4)
                {
                    readers.Add(new Reader()
                    {
                        Id = Convert.ToUInt32(ReaderData.fileReaders[j][0]),

                        FullName = ReaderData.fileReaders[j][1],

                        ReaderTicket = Convert.ToUInt32(ReaderData.fileReaders[j][2]),

                        DateCapture = new Dictionary<uint, DateTime>
                        {
                            { Convert.ToUInt32(TableData.fileTableDate[j][0]), Convert.ToDateTime(TableData.fileTableDate[j][2])}
                        },

                        DateReturn = new Dictionary<uint, DateTime>
                        {

                        }
                    });
                }
                else
                {
                    readers.Add(new Reader()
                    {
                        Id = Convert.ToUInt32(ReaderData.fileReaders[j][0]),

                        FullName = ReaderData.fileReaders[j][1],

                        ReaderTicket = Convert.ToUInt32(ReaderData.fileReaders[j][2]),

                        DateCapture = new Dictionary<uint, DateTime>
                        {
                            { Convert.ToUInt32(TableData.fileTableDate[j][0]), Convert.ToDateTime(TableData.fileTableDate[j][2])}
                        },

                        DateReturn = new Dictionary<uint, DateTime>
                        {
                            { Convert.ToUInt32(TableData.fileTableDate[j][0]), Convert.ToDateTime(TableData.fileTableDate[j][3])}
                        }
                    });
                }
            }

            List<Book> books = new List<Book>();

            for (int i = 1; i <= BookData.fileBooks.Length - 1; i++)
            {
                books.Add(new Book
                {
                    Id = Convert.ToUInt32(BookData.fileBooks[i][0]),

                    Author = BookData.fileBooks[i][1],

                    Title = BookData.fileBooks[i][2],

                    PublicationYear = Convert.ToUInt32(BookData.fileBooks[i][3]),

                    CabinetNumber = Convert.ToUInt32(BookData.fileBooks[i][4]),

                    ShelfNumber = Convert.ToUInt32(BookData.fileBooks[i][5]),
                });
            }
            bool status = false;
            foreach (var book in books)
            {
                foreach (var reader in readers)
                {
                    if (reader.DateCapture.ContainsKey(book.Id) && reader.DateReturn.ContainsKey(book.Id) == false)
                    {
                        Console.WriteLine($"{book.Title} {reader.FullName} {reader.DateCapture[book.Id].ToString("d")}");
                        status = true; break;
                    }
                }
                if(status == true) { status = false;  }
                else { Console.WriteLine(book.Title); }
            }
        }
        public static void Main(string[] args)
        {
            Programm dataBase = new Programm();
            dataBase.Initialize();
        }
    }
}
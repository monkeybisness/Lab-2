using System.Globalization;

namespace Lab
{
    class Programm
    {
        void Initialize()
        {
            BookData bookData = new BookData("C:\\Users\\User\\source\\repos\\Lab-2\\Lab-2\\Books\\Books.csv");
            bookData.CheckFile();

            ReaderData readerData = new ReaderData("C:\\Users\\User\\source\\repos\\Lab-2\\Lab-2\\Readers\\Readers.csv");
            readerData.CheckFile();

            TableData tableData = new TableData("C:\\Users\\User\\source\\repos\\Lab-2\\Lab-2\\TableDate\\TableDate.csv");
            tableData.CheckFile();

            List<Reader> readers = new List<Reader>();
            for (int j = 1; j <= tableData.fileTableDate.Count - 1; j++)
            {
                Reader reader = new Reader();
                if (tableData.fileTableDate[j].Count < 4) { readers.Add(reader.ReaderAddThree(readerData, tableData, j)); }
                else 
                { 
                    readers.Add(reader.ReaderAddThree(readerData, tableData, j));
                    readers[readers.Count - 1].DateReturn = new Dictionary<uint, DateTime>
                    {
                        { Convert.ToUInt32(tableData.fileTableDate[j][0]), Convert.ToDateTime(tableData.fileTableDate[j][3]) }
                    };
                }
            }

            List<Book> books = new List<Book>();
            for (int i = 1; i <= bookData.fileBooks.Count - 1; i++)
            {
                Book book = new Book();
                books.Add(book.BooksAdd(bookData, i));
            }
            foreach (var book in books)
            {
                book.BookReader(book, readers, false);
            }
        }
        public static void Main(string[] args)
        {
            Programm dataBase = new Programm();
            dataBase.Initialize();
        }
    }
}
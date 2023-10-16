using System.Globalization;

namespace Lab
{
    class Programm
    {
        void Initialize()
        {
            BookData bookData = new BookData("C:\\Users\\User\\source\\repos\\Lab-2\\Lab-2\\Books\\Books.csv", new List<List<string>>());
            bookData.CheckData();

            ReaderData readerData = new ReaderData("C:\\Users\\User\\source\\repos\\Lab-2\\Lab-2\\Readers\\Readers.csv", new List<List<string>>());
            readerData.CheckData();

            TableData tableData = new TableData("C:\\Users\\User\\source\\repos\\Lab-2\\Lab-2\\TableDate\\TableDate.csv", new List<List<string>>());
            tableData.CheckData();

            List<Reader> readers = new List<Reader>();
            for (int i = 1; i <= tableData.FileTableDate.Count - 1; i++)
            {
                Reader reader = new Reader();
                if(tableData.FileTableDate[i].Count < 4) 
                    { readers.Add(reader.ReaderAdd(readerData, tableData, i)); }
                else 
                { 
                    readers.Add(reader.ReaderAdd(readerData, tableData, i));
                    readers[readers.Count - 1].DateReturn = new Dictionary<uint, DateTime>
                    {
                        { Convert.ToUInt32(tableData.FileTableDate[i][0]), Convert.ToDateTime(tableData.FileTableDate[i][3]) }
                    };
                }
            }

            List<Book> books = new List<Book>();
            for (int i = 1; i <= bookData.FileBooks.Count - 1; i++)
            {
                Book book = new Book();
                books.Add(book.BooksAdd(bookData, i));
            }
            foreach (var book in books)
            {
                book.BookStatus(book, readers);
            }
        }
        public static void Main(string[] args)
        {
            Programm dataBase = new Programm();
            dataBase.Initialize();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Book
    {
        public Book() { }
        public uint Id {  get; set; }

        public string Author { get; set; }

        public string Title {  get; set; }

        public uint PublicationYear { get; set; }

        public uint CabinetNumber { get; set; }

        public uint ShelfNumber { get; set; }

        public Book BooksAdd(BookData bookData, int i)
        {
            return new Book
            {
                Id = Convert.ToUInt32(bookData.fileBooks[i][0]),

                Author = bookData.fileBooks[i][1],

                Title = bookData.fileBooks[i][2],

                PublicationYear = Convert.ToUInt32(bookData.fileBooks[i][3]),

                CabinetNumber = Convert.ToUInt32(bookData.fileBooks[i][4]),

                ShelfNumber = Convert.ToUInt32(bookData.fileBooks[i][5]),
            };

        }

        public void BookReader(Book book, List<Reader> readers , bool status)
        {
            foreach (Reader reader in readers)
            {
                if (reader.DateCapture.ContainsKey(book.Id) && reader.DateReturn.ContainsKey(book.Id) == false)
                {
                    Console.WriteLine($"{book.Title} {reader.FullName} {reader.DateCapture[book.Id].ToString("d")}");
                    status = true; break;
                }
            }
            if (status == true) { status = false; }
            else { Console.WriteLine(book.Title); }
        }
    }
}

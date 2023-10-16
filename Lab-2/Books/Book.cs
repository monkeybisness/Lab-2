using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public Book BooksAdd(BookData bookData, int row)
        {
            return new Book
            {
                Id = Convert.ToUInt32(bookData.FileBooks[row][0]),

                Author = bookData.FileBooks[row][1],

                Title = bookData.FileBooks[row][2],

                PublicationYear = Convert.ToUInt32(bookData.FileBooks[row][3]),

                CabinetNumber = Convert.ToUInt32(bookData.FileBooks[row][4]),

                ShelfNumber = Convert.ToUInt32(bookData.FileBooks[row][5]),
            };

        }

        public void BookStatus(Book book, List<Reader> readers)
        {
            var statusBook = book.Title;
            for (int i = 0; i < readers.Count; i++)
            {
                if (readers[i].DateCapture.ContainsKey(book.Id) && readers[i].DateReturn.ContainsKey(book.Id) == false)
                {
                    statusBook = $"{book.Title} {readers[i].FullName} {readers[i].DateCapture[book.Id].ToString("d")}";
                    break;
                }
            }
            Console.WriteLine(statusBook);
        }
    }
}

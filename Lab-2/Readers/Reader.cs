using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Reader
    {
        public uint Id { get; set; }

        public string FullName { get; set; }

        public uint ReaderTicket { get; set; }

        public Dictionary<uint, DateTime> DateCapture { get; set; }

        public Dictionary<uint, DateTime> DateReturn { get; set; }

        public Reader ReaderAdd(ReaderData readerData , TableData tableData, int row)
        {
            return new Reader()
            {
                Id = Convert.ToUInt32(readerData.FileReaders[row][0]),

                FullName = readerData.FileReaders[row][1],

                ReaderTicket = Convert.ToUInt32(readerData.FileReaders[row][2]),

                DateCapture = new Dictionary<uint, DateTime>
                {
                    { Convert.ToUInt32(tableData.FileTableDate[row][0]), Convert.ToDateTime(tableData.FileTableDate[row][2])}
                },

                DateReturn = new Dictionary<uint, DateTime> { }
            };
        }
    }
}

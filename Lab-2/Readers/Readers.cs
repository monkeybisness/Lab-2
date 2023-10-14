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

        public Reader ReaderAddThree(ReaderData readerData , TableData tableData, int j)
        {
            return new Reader()
            {
                Id = Convert.ToUInt32(readerData.fileReaders[j][0]),

                FullName = readerData.fileReaders[j][1],

                ReaderTicket = Convert.ToUInt32(readerData.fileReaders[j][2]),

                DateCapture = new Dictionary<uint, DateTime>
                {
                    { Convert.ToUInt32(tableData.fileTableDate[j][0]), Convert.ToDateTime(tableData.fileTableDate[j][2])}
                },

                DateReturn = new Dictionary<uint, DateTime>
                {

                }
            };
        }
        public Reader ReaderAddFour(ReaderData readerData, TableData tableData, int j)
        {
            return new Reader()
            {
                Id = Convert.ToUInt32(readerData.fileReaders[j][0]),

                FullName = readerData.fileReaders[j][1],

                ReaderTicket = Convert.ToUInt32(readerData.fileReaders[j][2]),

                DateCapture = new Dictionary<uint, DateTime>
                {
                    { Convert.ToUInt32(tableData.fileTableDate[j][0]), Convert.ToDateTime(tableData.fileTableDate[j][2])}
                },

                DateReturn = new Dictionary<uint, DateTime>
                {
                    { Convert.ToUInt32(tableData.fileTableDate[j][0]), Convert.ToDateTime(tableData.fileTableDate[j][3])}
                }
            };
        }

    }
}

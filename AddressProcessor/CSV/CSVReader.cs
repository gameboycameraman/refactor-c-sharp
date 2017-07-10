using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing
{
    class CSVReader
    {
        public StreamReader _readerStream = null;

        public bool Read(out string column1, out string column2)
        {
            const int FIRST_COLUMN = 0;
            const int SECOND_COLUMN = 1;

            char[] separator = { '\t' };
            string line = ReadLine();
            string[] columns = line.Split(separator);

            if (line == null)
            {
                column1 = null;
                column2 = null;

                return false;
            }

            if (columns.Length == 0)
            {
                column1 = null;
                column2 = null;

                return false;
            } 
            else
            {
                column1 = columns[FIRST_COLUMN];
                column2 = columns[SECOND_COLUMN];

                return true;
            }
        }

        public string ReadLine()
        {
            return _readerStream.ReadLine();
        }
    }
}

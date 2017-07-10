using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing
{
    class CSVWriter
    {

        public StreamWriter _writerStream = null;

        public void Write(params string[] columns)
        {
            string outPut = "";

            for (int i = 0; i < columns.Length; i++)
            {
                outPut += columns[i];
                if ((columns.Length - 1) != i)
                {
                    outPut += "\t";
                }
            }

            WriteLine(outPut);
        }

        public void WriteLine(string line)
        {
            _writerStream.WriteLine(line);
        }
    }
}

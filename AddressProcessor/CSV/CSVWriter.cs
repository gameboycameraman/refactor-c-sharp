using System;
using System.IO;

namespace AddressProcessing
{
    class CSVWriter
    {

        public StreamWriter writerStream = null;

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
            writerStream.WriteLine(line);
        }
    }
}

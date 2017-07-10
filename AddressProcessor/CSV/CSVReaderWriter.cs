using System;
using System.IO;

namespace AddressProcessing.CSV
{
    /*
        2) Refactor this class into clean, elegant, rock-solid & well performing code, without over-engineering.
           Assume this code is in production and backwards compatibility must be maintained.
    */

    public class CSVReaderWriter
    {

        private readonly CSVWriter _writer;

        public CSVReaderWriter(CSVWriter argWriter)
        {
            _writer = argWriter;
        }

        [Flags]
        public enum Mode { Read = 1, Write = 2 };

        public void Open(string fileName, Mode mode)
        {
            if (mode == Mode.Read)
            {
                _readerStream = File.OpenText(fileName);
            }
            else if (mode == Mode.Write)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                _writer.writerStream = fileInfo.CreateText();
            }
            else
            {
                throw new Exception("Unknown file mode for " + fileName);
            }
        }

        public void Close()
        {
            if (_writer.writerStream != null)
            {
                _writer.writerStream.Close();
            }

            if (_readerStream != null)
            {
                _readerStream.Close();
            }
        }
    }
}

using System;
using System.IO;

namespace AddressProcessing.CSV
{
    /*
        2) Refactor this class into clean, elegant, rock-solid & well performing code, without over-engineering.
           Assume this code is in production and backwards compatibility must be maintained.
    */

    class CSVReaderWriter
    {

        private readonly CSVWriter _writer;
        private readonly CSVReader _reader;

        public CSVReaderWriter(CSVWriter argWriter, CSVReader argReader)
        {
            _writer = argWriter;
            _reader = argReader;
        }

        [Flags]
        public enum Mode { Read = 1, Write = 2 };

        public void Open(string fileName, Mode mode)
        {
            if (mode == Mode.Read)
            {
                _reader.readerStream = File.OpenText(fileName);
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

            if (_reader.readerStream != null)
            {
                _reader.readerStream.Close();
            }
        }
    }
}

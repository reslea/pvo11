using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public class FileReader : IReader
    {
        private string _fileName;

        public FileReader(string fileName)
        {
            _fileName = fileName;
        }
        public IEnumerable<string> GetJsonLines()
        {
            using StreamReader sr = new StreamReader(_fileName);

            while (!sr.EndOfStream)
            {
                yield return sr.ReadLine()!;
            }
        }
    }
}

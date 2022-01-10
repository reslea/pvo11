using FileReader;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FileReaderTests
{
    public class JsonReaderTests
    {
        [Fact]
        public void JsonReaderWorks()
        {
            IReader fileReader = new FakeFileReader();
            var jsonReader = new JsonReader(fileReader);

            Assert.True(jsonReader.GetHeroes().Count() > 0);
        }

        [Fact]
        public void JsonReaderReturnsEmptyOnException()
        {
            IReader fileReader = new ExceptionFileReader();
            var jsonReader = new JsonReader(fileReader);

            Assert.Empty(jsonReader.GetHeroes());
        }
    }

    public class FakeFileReader : IReader
    {
        public IEnumerable<string> GetJsonLines()
        {
            yield return "{\"FirstName\":\"Peter3\",\"LastName\":\"Parker\",\"Age\":16,\"IsAvenger\":true}";
        }
    }

    public class ExceptionFileReader : IReader
    {
        public IEnumerable<string> GetJsonLines()
        {
            throw new Exception();
        }
    }
}
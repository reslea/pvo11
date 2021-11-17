using System;
using Xunit;
using ConsoleApp.Logic;

namespace VectorTests
{
    public class VectorUnitTests
    {
        [Fact]
        public void Clear_Works()
        {
            var vector = new Vector<int> { 1, 2, 3, 4 };

            vector.Clear();

            Assert.True(vector.Count == 0);
        }

        [Fact]
        public void Insert_Works()
        {
            var vector = new Vector<int> { 1, 2, 3, 4 };
            vector.Insert(0, 0);

            Assert.True(vector[0] == 0);
        }
    }
}
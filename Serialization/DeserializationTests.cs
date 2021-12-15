using Serialization.Converters;
using Serialization.Entities;
using Xunit;

namespace Serialization
{
    public class DeserializationTests
    {
        [Fact]
        public void Hero_Deserialization_Manual()
        {
            var inputJson = "{\"FirstName\":\"Peter\",\"LastName\":\"Parker\",\"Age\":16,\"IsAvenger\":true}";

            var expectedResult = new Hero
            {
                FirstName = "Peter",
                LastName = "Parker",
                Age = 16,
                IsAvenger = true
            };

            Hero actualResult = (Hero)JsonManualConvert_Serialize
                .Deserialize(inputJson, typeof(Hero));

            Assert.True(
                expectedResult.FirstName.Equals(actualResult.FirstName)
                && expectedResult.LastName.Equals(actualResult.LastName)
                && expectedResult.Age == actualResult.Age
                && expectedResult.IsAvenger == actualResult.IsAvenger);
        }
    }
}

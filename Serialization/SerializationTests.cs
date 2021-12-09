using Newtonsoft.Json;
using Xunit;

namespace Serialization
{
    public class SerializationTests
    {
        [Fact]
        public void Hero_Serialization_Manual()
        {
            var source = new Hero
            {
                FirstName = "Peter",
                LastName = "Parker",
                Age = 16,
                IsAvenger = true
            };
            var expectedResult = "{\"FirstName\":\"Peter\",\"LastName\":\"Parker\",\"Age\":16,\"IsAvenger\":true}";

            string actualResult = JsonManualConvert.Serialize(source);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Hero_Serialization_Reflection()
        {
            var source = new Hero
            {
                FirstName = "Peter",
                LastName = "Parker",
                Age = 16,
                IsAvenger = true
            };
            var expectedResult = "{\"FirstName\":\"Peter\",\"LastName\":\"Parker\",\"Age\":16,\"IsAvenger\":true}";

            string actualResult = JsonReflectionConvert.Serialize(source);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Serialize_Any_Type()
        {
            var person = new Person
            {
                Name = "Alex",
                Age = 33
            };
            var expectedResult = JsonConvert.SerializeObject(person);

            var actualResult = JsonReflectionConvert.Serialize(person);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}

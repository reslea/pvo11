using Newtonsoft.Json;
using Serialization.Converters;
using Serialization.Entities;
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

            string actualResult = JsonManualConvert_Serialize.Serialize(source);

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

        [Fact]
        public void Serialize_Type_Without_Setter()
        {
            var reader = new Reader
            {
                Name = "Inna",
                DateOfBirth = new DateTime(2000, 1, 1)
            };

            var expectedResult = JsonConvert.SerializeObject(reader);

            var actualResult = JsonReflectionConvert.Serialize(reader);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Serialize_Type_With_Nested_Object()
        {
            var reader = new Reader
            {
                Name = "Inna",
                DateOfBirth = new DateTime(2000, 1, 1),
                ReadableBook = new Book
                {
                    Title = "CLR via C#",
                    Description = "Very cool book about C#"
                },
            };

            var expectedResult = JsonConvert.SerializeObject(reader);

            var actualResult = JsonReflectionConvert.Serialize(reader);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Serialize_Type_With_Nested_List()
        {
            var reader = new Reader
            {
                Name = "Inna",
                DateOfBirth = new DateTime(2000, 1, 1),
                FafouriteBooks = new List<Book>
                {
                    new Book
                    {
                        Title = "CLR via C#",
                        Description = "Very cool book about C#"
                    }
                },
            };

            var expectedResult = JsonConvert.SerializeObject(reader);

            var actualResult = JsonReflectionConvert.Serialize(reader);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
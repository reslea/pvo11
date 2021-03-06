using FileReader;
using Xunit;

namespace DependencyInjectionTests
{
    public class ServiceLocatorTest
    {
        [Fact]
        public void RegistrationWorks()
        {
            var locator = new ServiceLocator();
            locator.Register<IReader>(new FileReader.FileReader("input.txt"));

            IReader reader = locator.GetService<IReader>();

            Assert.NotNull(reader);
        }

        [Fact]
        public void DependandObjectWorks()
        {
            var locator = new ServiceLocator();
            locator.Register<IReader>(() => new FileReader.FileReader("input.txt"));
            locator.Register<JsonReader>();

            JsonReader reader = locator.GetService<JsonReader>();

            Assert.NotNull(reader);
        }

        [Fact]
        public void ImplementationTypeWorks()
        {
            var locator = new ServiceLocator();
            locator.Register<IReader>(() => new FileReader.FileReader("input.txt"));
            locator.Register<IJsonReader, JsonReader>();

            IJsonReader reader = locator.GetService<IJsonReader>();

            Assert.NotNull(reader);
        }

        //[Fact]
        //public void BudgetRepoFormInjector()
        //{
        //    var locator = new ServiceLocator();
        //    locator.Register<IBudgetRepository, BudgetRepository>();
        //    locator.Register<MyForm>();

        //    locator.GetService<MyForm>();
        //}
    }
}
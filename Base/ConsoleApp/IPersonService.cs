using System;

namespace ConsoleApp;

public interface IPersonService
{
    int SumAges(Person person1, Person person2);
}

public class PersonService : IPersonService
{
    public int SumAges(Person person1, Person person2)
    {
        return person1 == null || person2 == null
            ? throw new Exception("Cannot sum null people")
            : person1.Age + person2.Age;
    }
}

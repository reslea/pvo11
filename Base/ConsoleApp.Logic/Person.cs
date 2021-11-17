namespace ConsoleApp;

public class Person
{
    public int Age { get; set; }

    public string Name { get; set; }

    public Person Mother { get;set; }

    public Person Father { get; set; }

    public Person(int age, string name, Person mother, Person father)
    {
        Age = age;
        Name = name;
        Mother = mother;
        Father = father;
    }

    public virtual void GrowUp()
    {
        Age++;
    }

    public virtual void GrowUp(int years)
    {
        Age += years;
    }

    public override string ToString()
    {
        return Name + " " + Age.ToString();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != typeof(Person))
        {
            return false;
        }

        Person p = (Person)obj;

        return Age == p.Age && Name == p.Name;
    }
}

public class Employee : Person
{
    public Employee(int age, string name, Person mother, Person father)
        : base(age, name, mother, father)
    {

    }

    public override void GrowUp()
    {
        throw new Exception();
    }

    public override void GrowUp(int years)
    {
        base.GrowUp(years);
    }
}

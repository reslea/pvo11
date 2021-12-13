using Serialization.Entities;
using System.Reflection;

var spidey = new Hero
{
  FirstName = "Peter",
  LastName = "Parker",
  Age = 16,
  IsAvenger = true
};

Type type = spidey.GetType();
MethodInfo[] methods = type.GetMethods();

MethodInfo firstNameGetter = methods[0];

Console.ReadLine();
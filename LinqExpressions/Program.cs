using LinqExpressions;
using Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

List<string> numbers = new() { "100", "2", "15", "3", "3" };

var heroes = new List<Hero> {
    new Hero { FirstName = "Peter", LastName = "Parker", Age = 16, IsAvenger = true },
    new Hero { FirstName = "Molly", LastName = "Jane", Age = 16, IsAvenger = false },
    new Hero { FirstName = "Tony", LastName = "Stark", Age = 48, IsAvenger = true },
    new Hero { FirstName = "Steve", LastName = "Rogers", Age = 100, IsAvenger = true },
    new Hero { FirstName = "Steven", LastName = "Strange", Age = 42, IsAvenger = false },
};

Console.WriteLine("Which hero you want to find?");
var searchTerm = Console.ReadLine();

Console.WriteLine("Here what we found:");

var foundHero = heroes
  .FirstOrDefault(h => h.FirstName.Contains(searchTerm) || h.LastName.Contains(searchTerm));

Console.WriteLine(foundHero);

var parsed = numbers
  .Distinct()
  .Select(int.Parse);

var moreThan3 = parsed
  .Where(num => num > 3);

var ordered = moreThan3
  .OrderBy(x => x);

var first = parsed.FirstOrDefault(num => num > 300000000);

ordered.Print();

// Здесь мы создаем много мусора а потом приходит сборщик
Console.WriteLine(GC.GetGeneration(numbers));
Random Random = new Random();
for (int i = 0; i < 100_000; i++)
{
  var randomList = new List<int> { Random.Next(), Random.Next(), Random.Next(), Random.Next() };
}
GC.Collect();

Console.WriteLine(GC.GetGeneration(numbers));


//numbers
//  .Filter()
//  .Print();

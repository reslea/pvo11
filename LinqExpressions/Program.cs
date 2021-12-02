using LinqExpressions;
using System.Collections.Generic;
using System.Linq;

List<string> numbers = new() { "100", "2", "15", "3" };

numbers
  .Select(int.Parse)
  .Where(num => num > 3)
  .OrderBy(x => x)
  .Print();

//numbers
//  .Filter()
//  .Print();


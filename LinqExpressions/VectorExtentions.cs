using System;
using System.Collections.Generic;

namespace LinqExpressions;

public static class VectorExtentions
{
  public static void Print<TItem>(this IEnumerable<TItem> numbers)
  {
    foreach (var item in numbers)
    {
      Console.WriteLine(item);
    }
  }

  public static IEnumerable<int> Filter(this IEnumerable<int> collection)
  {
    foreach (var item in collection)
    {
      if(item > 2)
      {
        yield return item;
      }
    }
  }
}

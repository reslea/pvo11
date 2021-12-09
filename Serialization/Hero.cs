using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
  public class Hero
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public bool IsAvenger { get; set; }

    public override string ToString()
    {
      return $"{FirstName} {LastName}";
    }
  }
}

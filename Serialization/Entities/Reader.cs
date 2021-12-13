using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Entities
{
    public class Reader
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age => (DateTime.Now - DateOfBirth).Days / 365;

        public Book? ReadableBook { get; set; }

        public List<Book>? FafouriteBooks { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

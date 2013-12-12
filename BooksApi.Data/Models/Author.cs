using System;
using System.Collections.Generic;

namespace BooksApi.Data.Models
{
    public partial class Author
    {
        public Author()
        {
            this.Books = new List<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}

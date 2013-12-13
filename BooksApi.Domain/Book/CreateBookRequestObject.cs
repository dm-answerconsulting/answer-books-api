using System;
using BooksApi.Domain.Validation;

namespace BooksApi.Domain.Book
{
    public class CreateBookRequestObject : ValidationObject
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
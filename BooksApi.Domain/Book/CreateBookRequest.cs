using System;

namespace BooksApi.Domain.Book
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
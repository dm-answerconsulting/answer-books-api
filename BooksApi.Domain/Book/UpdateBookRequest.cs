namespace BooksApi.Domain.Book
{
    public class UpdateBookRequest : CreateBookRequest
    {
        public int Id { get; set; }
    }
}
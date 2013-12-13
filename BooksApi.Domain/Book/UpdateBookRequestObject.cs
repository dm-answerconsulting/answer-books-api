namespace BooksApi.Domain.Book
{
    public class UpdateBookRequestObject : CreateBookRequestObject
    {
        public int Id { get; set; }
    }
}
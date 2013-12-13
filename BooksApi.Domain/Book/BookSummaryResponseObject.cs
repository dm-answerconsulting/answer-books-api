namespace BooksApi.Domain
{
    public class BookSummaryResponseObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string GenreName { get; set; }
    }
}
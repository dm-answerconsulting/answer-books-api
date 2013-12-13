using System;

namespace BooksApi.Domain
{
    public class BookDetailsRequestObject : BookSummaryRequestObject
    {
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
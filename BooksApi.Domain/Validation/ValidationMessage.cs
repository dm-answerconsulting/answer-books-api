namespace BooksApi.Domain.Validation
{
    public class ValidationMessage
    {
        public string PropertyName { get; set; }

        public string Message { get; set; }

        public string Code { get; set; }
    }
}
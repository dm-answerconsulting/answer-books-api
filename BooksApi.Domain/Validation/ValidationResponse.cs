using System.Collections.Generic;

namespace BooksApi.Domain.Validation
{
    public class ValidationResponse
    {
        public string TargetName { get; set; }

        public IList<ValidationMessage> Errors { get; set; }

        public IList<ValidationMessage> Warnings { get; set; }
    }
}

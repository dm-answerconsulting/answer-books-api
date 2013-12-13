using System.Collections.Generic;

namespace BooksApi.Domain.Validation
{
    public class ValidationObject
    {
        public IList<ValidationMessage> ValidationErrors { get; set; }

        public IList<ValidationMessage> ValidationWarnings { get; set; }
    }
}

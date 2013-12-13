using System.Linq;
using System.Net.Http.Formatting;

namespace BooksApi.Web
{
    public class FormatterConfig
    {
        public static void RegisterGlobalFormatters(MediaTypeFormatterCollection fomratters)
        {
            var appXmlType = fomratters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            fomratters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}

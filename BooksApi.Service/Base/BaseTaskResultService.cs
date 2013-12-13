using System.Threading.Tasks;

namespace BooksApi.Service.Base
{
    public class BaseTaskResultService
    {
        public Task<T> CreateFacadeTask<T>(T result)
        {
            var completion = new TaskCompletionSource<T>();

            completion.SetResult(result);

            return completion.Task;
        }
    }
}

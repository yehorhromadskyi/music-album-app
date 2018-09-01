using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace MusicAlbumApp.Core.Services.Implementation
{
    public class SerializationService : ISerializationService
    {
        public Task<TResult> DeserializeAsync<TResult>(Stream stream)
        {
            var completion = new TaskCompletionSource<TResult>();

            // It's not truly asynchronous, because underneath
            // ThreadPool's thread is still doing all the work
            // but for caller it looks asynchronous
            Task.Run(() =>
            {
                using (var streamReader = new StreamReader(stream))
                using (var reader = new JsonTextReader(streamReader))
                {
                    var serializer = new JsonSerializer();

                    try
                    {
                        // This string will lead to crash on Android if call it from the UI thread
                        // because this call is synchronous and it blocks the UI thread
                        var result = serializer.Deserialize<TResult>(reader);
                        completion.TrySetResult(result);
                    }
                    catch (System.Exception ex)
                    {
                        completion.TrySetException(ex);
                    }
                }
            });

            return completion.Task;
        }
    }
}

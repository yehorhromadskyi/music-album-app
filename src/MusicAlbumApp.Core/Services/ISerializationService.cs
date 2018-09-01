using System.IO;
using System.Threading.Tasks;

namespace MusicAlbumApp.Core.Services
{
    public interface ISerializationService
    {
        Task<TResult> DeserializeAsync<TResult>(Stream stream);
    }
}

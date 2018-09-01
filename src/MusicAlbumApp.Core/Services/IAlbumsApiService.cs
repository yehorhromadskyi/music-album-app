using MusicAlbumApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicAlbumApp.Core.Services
{
    public interface IAlbumsApiService
    {
        Task<List<Album>> GetAlbumsAsync();
        
        Task<List<AlbumDetails>> GetAlbumDetailsAsync(int albumId);
    }
}

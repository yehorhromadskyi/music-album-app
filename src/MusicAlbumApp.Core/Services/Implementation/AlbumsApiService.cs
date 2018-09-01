using MusicAlbumApp.Core.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicAlbumApp.Core.Services.Implementation
{
    public class AlbumsApiService : IAlbumsApiService
    {
        readonly static string BaseUrl = "https://jsonplaceholder.typicode.com/{0}";
        readonly string GetAlbumsUrl = string.Format(BaseUrl, "albums");
        readonly string GetAlbumDetailsUrl = string.Format(BaseUrl, "photos?albumId={0}");

        readonly HttpClient _httpClient;
        readonly ISerializationService _serializationService;

        public AlbumsApiService(HttpClient httpClient, ISerializationService serializationService)
        {
            _httpClient = httpClient;
            _serializationService = serializationService;
        }

        public async Task<List<Album>> GetAlbumsAsync()
        {
            var albums = new List<Album>();

            using (var stream = await _httpClient.GetStreamAsync(GetAlbumsUrl))
            {
                albums = await _serializationService.DeserializeAsync<List<Album>>(stream);
            }

            return albums;
        }

        public async Task<List<AlbumDetails>> GetAlbumDetailsAsync(int albumId)
        {
            var albumDetails = new List<AlbumDetails>();
            var url = string.Format(GetAlbumDetailsUrl, albumId);

            using (var stream = await _httpClient.GetStreamAsync(url))
            {
                albumDetails = await _serializationService.DeserializeAsync<List<AlbumDetails>>(stream);
            }

            return albumDetails;
        }
    }
}

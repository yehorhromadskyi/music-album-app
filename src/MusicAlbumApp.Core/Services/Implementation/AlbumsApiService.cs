using MusicAlbumApp.Core.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicAlbumApp.Core.Services.Implementation
{
    public class AlbumsApiService : IAlbumsApiService
    {
        readonly string GetAlbumsUrl = "https://jsonplaceholder.typicode.com/albums";

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
    }
}

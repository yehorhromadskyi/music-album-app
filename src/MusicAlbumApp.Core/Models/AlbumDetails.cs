using Newtonsoft.Json;

namespace MusicAlbumApp.Core.Models
{
    public class AlbumDetails : Album
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("ThumbnailUrl")]
        public string ThumbnailUrl { get; set; }
    }
}

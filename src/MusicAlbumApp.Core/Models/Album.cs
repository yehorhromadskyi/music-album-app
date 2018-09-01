using Newtonsoft.Json;

namespace MusicAlbumApp.Core.Models
{
    public class Album
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}

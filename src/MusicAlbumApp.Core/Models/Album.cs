﻿using Newtonsoft.Json;

namespace MusicAlbumApp.Core.Models
{
    public class Album
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}

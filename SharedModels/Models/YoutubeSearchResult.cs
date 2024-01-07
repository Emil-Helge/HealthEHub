using System.Text.Json.Serialization;

namespace SharedModels.Models
{
    public class YoutubeSearchResult
    {
        [JsonPropertyName("contents")]
        public Content[] Contents { get; set; } = [];
        [JsonPropertyName("estimatedResults")]
        public string EstimatedResults { get; set; } = string.Empty;
        [JsonPropertyName("next")]
        public string Next { get; set; } = string.Empty;
    }

    public class Content
    {
        [JsonPropertyName("video")]
        public Video Video { get; set; } = new Video();
    }

    public class Video
    {
        [JsonPropertyName("channelId")]
        public string ChannelId { get; set; } = string.Empty;
        [JsonPropertyName("channelName")]
        public string ChannelName { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("lengthText")]
        public string LengthText { get; set; } = string.Empty;
        [JsonPropertyName("publishedTimeText")]
        public string PublishedTimeText { get; set; } = string.Empty;
        [JsonPropertyName("thumbnails")]
        public Thumbnail[] Thumbnails { get; set; } = [];
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        [JsonPropertyName("videoId")]
        public string VideoId { get; set; } = string.Empty;
        [JsonPropertyName("viewCountText")]
        public string ViewCountText { get; set; } = string.Empty;
    }

    public class Thumbnail
    {
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}


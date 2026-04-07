using System.Text.Json.Serialization;

namespace NewsHub.Infrastructure.Models
{
    /// <summary>
    /// HTTPクライアントを使用してNewsAPIから取得したJSONデータを受け取るためのクラス
    /// </summary>
    public class NewsApiResponse
    {
        [JsonPropertyName("articles")]
        public List<NewsApiArticle> Articles { get; set; } = new();
    }

    public class NewsApiArticle
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("urlToImage")]
        public string? UrlToImage { get; set; }

        [JsonPropertyName("publishedAt")]
        public DateTime PublishedAt { get; set; }

        [JsonPropertyName("source")]
        public NewsApiSource? Source { get; set; }
    }

    public class NewsApiSource
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
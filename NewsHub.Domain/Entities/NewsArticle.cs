namespace NewsHub.Domain.Entities
{
    public class NewsArticle
    {
        /// <summary>タイトル</summary>
        public string? Title { get; set; }

        /// <summary>説明文</summary>
        public string? ExplanatoryText { get; set; }

        /// <summary>記事のURL</summary>
        public string? ArticleUrl { get; set; }

        /// <summary>画像のURL</summary>
        public string? ImageUrl{ get; set; }

        /// <summary>ニュースソース名</summary>
        public string? SourceName { get; set; }

        /// <summary>公開日時</summary>
        public DateTime PublishedDate { get; set; }

    }
}

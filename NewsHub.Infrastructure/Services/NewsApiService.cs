using Microsoft.Extensions.Configuration;
using NewsHub.Domain.Entities;
using NewsHub.Domain.Interfaces;
using NewsHub.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace NewsHub.Infrastructure.Services
{
    public class NewsApiService : INewsService
    {
        private readonly string _apiKey;

        public NewsApiService(IConfiguration configuration)
        {
            var apiKey = configuration["NewsApi:ApiKey"];

            _apiKey = apiKey;
        }

        public async Task<List<NewsArticle>> SearchAsync(string keyword)
        {
            // 検索文字からNewsAPIのURLを生成
            var url = $"https://newsapi.org/v2/everything?q={keyword}&apiKey={_apiKey}";

            // HTTPクライアントを使用してNewsAPIからJSONデータを取得
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);

            // JSON → NewsApiResponse への変換処理
            var response = JsonSerializer.Deserialize<NewsApiResponse>(json);

            // JSON → NewsArticle への変換処理
            var articles = new List<NewsArticle>();
            
            foreach (var item in response.Articles)
            {
                var article = new NewsArticle
                {
                    Title = item.Title,
                    ExplanatoryText = item.Description,
                    ArticleUrl = item.Url,
                    ImageUrl = item.UrlToImage,
                    SourceName = item.Source?.Name,
                    PublishedDate = item.PublishedAt
                };
                articles.Add(article);
            }

            return articles;
        }
    }
}

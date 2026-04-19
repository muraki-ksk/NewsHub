using Microsoft.Extensions.Configuration;
using NewsHub.Domain.Entities;
using NewsHub.Domain.Interfaces;
using NewsHub.Infrastructure.Models;
using System.Text.Json;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;

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
            try
            {
                // NewsAPIクライアントを使用してNewsAPIからデータを取得
                var newsApiClient = new NewsApiClient(_apiKey);
                var articlesResponse = await newsApiClient.GetEverythingAsync(new EverythingRequest
                {
                    Q = keyword,
                    SortBy = SortBys.Popularity,
                    Language = Languages.EN,
                    From = DateTime.Today.AddDays(-7) // 過去7日間のニュースを取得
                });

                // ステータスチェック
                if (articlesResponse.Status != Statuses.Ok)
                {
                    throw new Exception($"NewsAPI Error: {articlesResponse.Error?.Code} - {articlesResponse.Error?.Message}");
                }

                // NewsArticle への変換処理
                var articles = new List<NewsArticle>();
            
                foreach (var item in articlesResponse.Articles)
                {
                    var article = new NewsArticle
                    {
                        Title = item.Title,
                        ExplanatoryText = item.Description,
                        ArticleUrl = item.Url,
                        ImageUrl = item.UrlToImage,
                        SourceName = item.Source?.Name,
                        PublishedDate = (DateTime)item.PublishedAt
                    };
                    articles.Add(article);
                }

                return articles;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}

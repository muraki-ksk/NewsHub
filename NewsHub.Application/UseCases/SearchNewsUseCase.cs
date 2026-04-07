using NewsHub.Domain.Entities;
using NewsHub.Domain.Interfaces;

namespace NewsHub.Application.UseCases
{
    public class SearchNewsUseCase
    {
        private readonly INewsService _newsService;

        public SearchNewsUseCase(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<List<NewsArticle>> ExecuteAsync(string keyword)
        {
            // キーワードが空なら空リストを返す
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return new List<NewsArticle>();
            }

            return await _newsService.SearchAsync(keyword);
        }
    }
}
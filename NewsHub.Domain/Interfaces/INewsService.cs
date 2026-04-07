using NewsHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsHub.Domain.Interfaces
{
    public interface INewsService
    {
        /// <summary>
        /// NewsAPIより記事を取得する
        /// </summary>
        /// <param name="keyword">検索文字</param>
        /// <returns></returns>
        Task<List<NewsArticle>> SearchAsync(string keyword);
    }
}
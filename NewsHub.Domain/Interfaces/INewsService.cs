using NewsHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsHub.Domain.Interfaces
{
    internal interface INewsService
    {
        /// <summary>
        /// NewsAPIより記事を取得する
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        Task<List<NewsArticle>> SearchAsync(string keyword);
    }
}
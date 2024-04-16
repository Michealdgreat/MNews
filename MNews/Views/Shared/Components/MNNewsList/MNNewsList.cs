using Microsoft.AspNetCore.Mvc;
using MNews.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MNews.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MNews.Views.Shared.Components.MNNewsList
{

    public class MNNewsList : ViewComponent
    {
        private readonly IMemoryCache _cache;
        private readonly string _apiKey;

        public MNNewsList(IConfiguration configuration, IMemoryCache cache)
        {
            _apiKey = configuration.GetValue<string>("apiKey");
            //Implemented caching because it takes some time to complete roundtrip and data fetching
            _cache = cache;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool randomize, int noOfArticle)
        {
            var cacheKey = $"News-{randomize}-{noOfArticle}";
            if (!_cache.TryGetValue(cacheKey, out List<ArticleModel> cachedNews))
            {
                string apiUrl = "https://newsapi.org/v2/everything?q=tech&from=2024-04-13&to=2024-04-15&sortBy=popularity&apiKey=";
                string getRequestUrl = $"{apiUrl}{_apiKey}";

                var newsService = new NewsService(getRequestUrl);
                var news = await newsService.GetNewsAsync(_apiKey);

                if (randomize)
                {
                    var rand = new Random();
                    news = news.OrderBy(x => rand.Next()).Take(noOfArticle).ToList();
                }

                // Cache news data with expiration settings
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10))  // Cache for 10 minutes
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1));  // Invalidate cache after 60 mins

                _cache.Set(cacheKey, news, cacheEntryOptions);
                cachedNews = news;
            }

            return View(cachedNews);
        }
    }


}

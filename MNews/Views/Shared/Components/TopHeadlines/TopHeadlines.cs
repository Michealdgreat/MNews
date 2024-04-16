using Microsoft.AspNetCore.Mvc;
using MNews.Service;

namespace MNews.Views.Shared.Components.TopHeadlines
{
    public class TopHeadlines(IConfiguration configuration) : ViewComponent
    {
        private readonly string _apiKey = configuration.GetValue<string>("apiKey");

        public async Task<IViewComponentResult> InvokeAsync(bool randomize, string articleQuery)
        {
            string apiUrl = "https://newsapi.org/v2/everything?q=";

            string getRequestUrl = $"{apiUrl}{articleQuery}&apikey={_apiKey}";

            var newsService = new NewsService(getRequestUrl);
            var news = await newsService.GetNewsAsync(_apiKey);

            if (randomize)
            {
                var randNews = new Random();
                news = news.OrderBy(x => randNews.Next()).ToList();
            }
            return View(news);
        }
    }
}

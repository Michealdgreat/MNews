using Microsoft.AspNetCore.Mvc;
using MNews.Models;
using MNews.Service;

namespace MNews.Views.Shared.Components.TopHeadlines
{
    public class TopHeadlines(IConfiguration configuration) : ViewComponent
    {
        private readonly string _apiKey = configuration.GetValue<string>("apiKey");

        public IViewComponentResult Invoke(int count)
        {

            // Your view component logic here
            string apiUrl = "https://newsapi.org/v2/top-headlines?country=ru&apiKey=";
            string GetrequestUrl = $"{apiUrl}{_apiKey}";

            var newsService = new NewsService(GetrequestUrl);
            _ = newsService.GetNewsAsync(_apiKey);
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MNews.Service;

namespace MNews.Controllers
{
    public class SearchNewsController(IConfiguration configuration) : Controller
    {
        private readonly string _apiKey = configuration.GetValue<string>("apiKey");


        public async Task<IActionResult> SearchByQuery(string SearchQuery)
        {
            string apiUrl = "https://newsapi.org/v2/everything?q=";

            string getRequestUrl = $"{apiUrl}{SearchQuery}&apikey={_apiKey}";

            var newsService = new NewsService(getRequestUrl);
            var news = await newsService.GetNewsAsync(_apiKey);
            return View(news);
        }
    }
}

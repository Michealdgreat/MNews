using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MNews.Service;
using System.Configuration;

namespace MNews.Controllers
{
    public class NewsController(IConfiguration configuration) : Controller
    {


        private readonly string _apiKey = configuration.GetValue<string>("apiKey");


        public async Task<IActionResult> Index()
        {
            var newsService = new NewsService();
            var news = await newsService.GetNewsAsync(_apiKey);
            return View(news);
        }
    }
}

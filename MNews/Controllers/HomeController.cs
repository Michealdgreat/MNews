using Microsoft.AspNetCore.Mvc;
using MNews.Models;
using MNews.Service;
using System.Configuration;
using System.Diagnostics;

namespace MNews.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IConfiguration configuration) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly string _apiKey = configuration.GetValue<string>("apiKey");

        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://newsapi.org/v2/everything?q=finland&apikey=";
            string GetrequestUrl = $"{apiUrl}{_apiKey}";

            var newsService = new NewsService(GetrequestUrl);
            var news = await newsService.GetNewsAsync(_apiKey);
            return View(news);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

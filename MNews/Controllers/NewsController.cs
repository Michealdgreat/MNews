using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MNews.Service;

namespace MNews.Controllers
{
    public class NewsController : Controller
    {

        private readonly string _apiKey = "d9ab75985be34739a45d52acfc196efa";

        public async Task<IActionResult> Index()
        {
            var newsService = new NewsService();
            var news = await newsService.GetNewsAsync(_apiKey);
            return View(news);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MNews.Models;
using MNews.Service;
using System.Configuration;
using System.Diagnostics;
using System.Security.Policy;

namespace MNews.Controllers;

public class HomeController(ILogger<HomeController> logger, IConfiguration configuration) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly string _apiKey = configuration.GetValue<string>("apiKey");
    List<ArticleModel> news;
    public async Task<IActionResult> Index()
    {
        string apiUrl = "https://newsapi.org/v2/everything?q=finland&apikey=";
        string GetrequestUrl = $"{apiUrl}{_apiKey}";

        var newsService = new NewsService(GetrequestUrl);
        news = await newsService.GetNewsAsync(_apiKey);
        HttpContext.Session.Set("Articles", news);

        return View(news);
    }


    public IActionResult ArticleDetails(string url)
    {
        // Retrieve the list from session
        var articles = HttpContext.Session.Get<List<ArticleModel>>("Articles");
        // Find the specific article
        var article = articles?.FirstOrDefault(a => a.Title == url);

        return View(article);
    }
}
using Microsoft.AspNetCore.Mvc;
using MNews.Models;
using MNews.Service;

namespace MNews.Controllers;

public class SearchNewsController(IConfiguration configuration) : Controller
{
    private readonly string _apiKey = configuration.GetValue<string>("apiKey");


    public async Task<IActionResult> SearchByQuery(string SearchQuery)
    {
        string apiUrl = "https://newsapi.org/v2/everything?q=";

        string getRequestUrl = $"{apiUrl}{SearchQuery}&apikey={_apiKey}";

        var newsService = new NewsService(getRequestUrl);
        var news = await newsService.GetNewsAsync(_apiKey);
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
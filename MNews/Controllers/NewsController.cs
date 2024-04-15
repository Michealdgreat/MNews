using Microsoft.AspNetCore.DataProtection.KeyManagement;
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
			string apiUrl = "https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey=";
			string GetrequestUrl = $"{apiUrl}{_apiKey}";

			var newsService = new NewsService(GetrequestUrl);
			var news = await newsService.GetNewsAsync(_apiKey);
			return View(news);
		}

		public async Task<IActionResult> Technology()
		{
			string apiUrl = "https://newsapi.org/v2/everything?q=technology&apiKey=";
			string GetrequestUrl = $"{apiUrl}{_apiKey}";

			var newsService = new NewsService(GetrequestUrl);
			var news = await newsService.GetNewsAsync(_apiKey);
			return View(news);
		}

	}
}

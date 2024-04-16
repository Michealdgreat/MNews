﻿using MNews.Models;
using Newtonsoft.Json;

namespace MNews.Service;

public class NewsService(string requestUrl)
{
    private readonly string _requestUrl = requestUrl;

    public async Task<List<ArticleModel>?> GetNewsAsync(string apiKey)
    {
        using var httpClient = new HttpClient();

        HttpClient client = new();
        client.DefaultRequestHeaders.Add("User-Agent", "MN News/1.0");

        HttpRequestMessage request = new(HttpMethod.Get, _requestUrl);
        request.Headers.Add("Authorization", "Bearer " + apiKey);

        HttpResponseMessage CheckStatusCode = await client.SendAsync(request);

        using var response = await httpClient.GetAsync(_requestUrl);
        string apiResponse = await response.Content.ReadAsStringAsync();
        var newsApiResponse = JsonConvert.DeserializeObject<ApiResponseModel>(apiResponse);

        // check if its a 200 OK Response from API and check id Article list is not 0
        if (newsApiResponse != null && newsApiResponse.Articles != null)
        {
            //return only arcle with featured image
            var articlesWithImgUrl = newsApiResponse.Articles
                .Where(article => !string.IsNullOrEmpty(article.UrlToImage)).ToList();

            return articlesWithImgUrl;

        }
        else
        {
            throw new Exception("Failed to fetch data from News API.");
        }
    }
}

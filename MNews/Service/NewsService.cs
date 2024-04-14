using MNews.Models;
using Newtonsoft.Json;

namespace MNews.Service
{
    public class NewsService(string requestUrl)
    {
        public async Task<List<ArticleModel>?> GetNewsAsync(string apiKey)
        {
            using var httpClient = new HttpClient();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "MN News/1.0");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("Authorization", "Bearer " + apiKey);

            HttpResponseMessage CheckStatusCode = await client.SendAsync(request);

            using var response = await httpClient.GetAsync(requestUrl);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var newsApiResponse = JsonConvert.DeserializeObject<ApiResponseModel>(apiResponse);

            return newsApiResponse == null ? throw new Exception("Failed to fetch data from News API.") : newsApiResponse.Articles;
        }

    }
}

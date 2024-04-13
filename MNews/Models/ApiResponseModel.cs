namespace MNews.Models
{
    public class ApiResponseModel
    {
        public string? Status { get; set; }
        public int TotalResults { get; set; }
        public List<ArticleModel>? Articles { get; set; }
    }
}

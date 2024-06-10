using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionConf.Shared.Models;

namespace GestionConf.Client.Services
{
    public class ArticleService : IArticleService
    {
        private readonly HttpClient _httpClient;

        public ArticleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Article>> GetAllArticles()
        {
            return await _httpClient.GetFromJsonAsync<List<Article>>("api/Article");
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Article>($"api/Article/{id}");
        }

        public async Task<Article> AddArticle(Article article)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Article", article);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Article>();
        }

        public async Task<bool> DeleteArticle(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Article/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task UpdateArticle(Article article)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Article/{article.IdArticle}", article);
            response.EnsureSuccessStatusCode();
        }
    }
}

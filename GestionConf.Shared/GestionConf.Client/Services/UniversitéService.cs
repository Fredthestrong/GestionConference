using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionConf.Shared.Models;

namespace GestionConf.Client.Services
{
    public class UniversitéService : IUniversitéService
    {
        private readonly HttpClient _httpClient;

        public UniversitéService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Université>> GetAllUniversités()
        {
            return await _httpClient.GetFromJsonAsync<List<Université>>("api/Université");
        }

        public async Task<Université> GetUniversitéById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Université>($"api/Université/{id}");
        }

        public async Task<Université> AddUniversité(Université université)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Université", université);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Université>();
        }

        public async Task<bool> DeleteUniversité(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Université/{id}");
            return response.IsSuccessStatusCode;
        }

        public void UpdateUniversité(Université université)
        {
            throw new NotImplementedException();
        }

        public void DeleteUniversité(Task<Université> universitéToDelete)
        {
            throw new NotImplementedException();
        }
    }
}

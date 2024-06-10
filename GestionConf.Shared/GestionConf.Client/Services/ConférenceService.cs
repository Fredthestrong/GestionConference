using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionConf.Shared.Models;

namespace GestionConf.Client.Services
{
    public class ConférenceService : IConférenceService
    {
        private readonly HttpClient _httpClient;

        public ConférenceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Conférence>> GetAllConférences()
        {
            return await _httpClient.GetFromJsonAsync<List<Conférence>>("api/Conférence");
        }

        public async Task<Conférence> GetConférenceById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Conférence>($"api/Conférence/{id}");
        }

        public async Task<Conférence> AddConférence(Conférence conférence)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Conférence", conférence);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Conférence>();
        }

        public async Task<bool> UpdateConférence(Conférence conférence)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Conférence/{conférence.IdConférence}", conférence);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteConférence(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Conférence/{id}");
            return response.IsSuccessStatusCode;
        }

        public void DeleteConférence(Task<Conférence> conférenceToDelete)
        {
            throw new NotImplementedException();
        }
    }
}

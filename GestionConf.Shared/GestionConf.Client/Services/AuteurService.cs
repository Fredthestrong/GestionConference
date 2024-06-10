using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionConf.Shared.Models;

namespace GestionConf.Client.Services
{
    public class AuteurService : IAuteurService
    {
        private readonly HttpClient _httpClient;

        public AuteurService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Auteur>> GetAllAuteurs()
        {
            return await _httpClient.GetFromJsonAsync<List<Auteur>>("api/Auteur");
        }

        public async Task<Auteur> GetAuteurById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Auteur>($"api/Auteur/{id}");
        }

        public async Task<Auteur> AddAuteur(Auteur auteur)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auteur", auteur);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Auteur>();
        }

        public async Task<bool> UpdateAuteur(Auteur auteur)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Auteur/{auteur.IdAuteur}", auteur);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAuteur(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Auteur/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionConf.Shared.Models;

namespace GestionConf.Client.Services
{
    public class EntrepriseService : IEntrepriseService
    {
        private readonly HttpClient _httpClient;

        public EntrepriseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Entreprise>> GetAllEntreprises()
        {
            return await _httpClient.GetFromJsonAsync<List<Entreprise>>("api/Entreprise");
        }

        public async Task<Entreprise> GetEntrepriseById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Entreprise>($"api/Entreprise/{id}");
        }

        public async Task<Entreprise> AddEntreprise(Entreprise entreprise)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Entreprise", entreprise);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Entreprise>();
        }

        public async Task<bool> DeleteEntreprise(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Entreprise/{id}");
            return response.IsSuccessStatusCode;
        }

        public void UpdateEntreprise(Entreprise entreprise)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntreprise(Task<Entreprise> entrepriseToDelete)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionConf.Shared.Models;

namespace GestionConf.Client.Services
{
    public class RelecteurService : IRelecteurService
    {
        private readonly HttpClient _httpClient;

        public RelecteurService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Relecteur>> GetAllRelecteurs()
        {
            return await _httpClient.GetFromJsonAsync<List<Relecteur>>("api/Relecteur");
        }

        public async Task<Relecteur> GetRelecteurById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Relecteur>($"api/Relecteur/{id}");
        }

        public async Task<Relecteur> AddRelecteur(Relecteur relecteur)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Relecteur", relecteur);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Relecteur>();
        }

        public async Task<bool> DeleteRelecteur(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Relecteur/{id}");
            return response.IsSuccessStatusCode;
        }

        public void DeleteRelecteur(Task<Relecteur> relecteurToDelete)
        {
            throw new NotImplementedException();
        }

        public void UpdateRelecteur(Relecteur relecteur)
        {
            throw new NotImplementedException();
        }
    }
}

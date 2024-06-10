using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GestionConf.Shared.Models;

namespace GestionConf.Client.Services
{
    public class AdministrateurService : IAdministrateurService
    {
        private readonly HttpClient _httpClient;

        public AdministrateurService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Administrateur>> GetAllAdministrateurs()
        {
            return await _httpClient.GetFromJsonAsync<List<Administrateur>>("api/Administrateur");
        }

        public async Task<Administrateur> GetAdministrateurById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Administrateur>($"api/Administrateur/{id}");
        }

        public async Task<Administrateur> GetAdminByEmail(string email)
        {
            return await _httpClient.GetFromJsonAsync<Administrateur>($"api/Administrateur/GetAdminByEmail/{email}");
        }

        public async Task<Administrateur> Enregistrer(Administrateur administrateur)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Administrateur/Enregistrer", administrateur);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Administrateur>();
        }

        public async Task<bool> DeleteAdmin(string email)
        {
            var response = await _httpClient.DeleteAsync($"api/Administrateur/DeleteAdmin/{email}");
            return response.IsSuccessStatusCode;
        }

        public async Task<Administrateur> AddAdministrateur(Administrateur administrateur)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Administrateur", administrateur);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Administrateur>();
        }

        public async Task UpdateAdministrateur(Administrateur administrateur)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Administrateur/{administrateur.IdAdmin}", administrateur);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteAdministrateur(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Administrateur/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}


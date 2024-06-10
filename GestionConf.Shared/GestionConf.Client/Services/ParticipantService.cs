using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionConf.Shared.Models;

namespace GestionConf.Client.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly HttpClient _httpClient;

        public ParticipantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Participant>> GetAllParticipants()
        {
            return await _httpClient.GetFromJsonAsync<List<Participant>>("api/Participant");
        }

        public async Task<Participant> GetParticipantById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Participant>($"api/Participant/{id}");
        }

        public async Task<Participant> AddParticipant(Participant participant)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Participant", participant);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Participant>();
        }

        public async Task<bool> DeleteParticipant(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Participant/{id}");
            return response.IsSuccessStatusCode;
        }

        public void UpdateParticipant(Participant participant)
        {
            throw new NotImplementedException();
        }

        public void DeleteParticipant(Task<Participant> participantToDelete)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionConf.Shared.Models;

namespace GestionConf.Client.Services
{
    public class EvaluationService : IEvaluationService
    {
        private readonly HttpClient _httpClient;

        public EvaluationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Evaluation>> GetAllEvaluations()
        {
            return await _httpClient.GetFromJsonAsync<List<Evaluation>>("api/Evaluation");
        }

        public async Task<Evaluation> GetEvaluationById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Evaluation>($"api/Evaluation/{id}");
        }

        public async Task<Evaluation> AddEvaluation(Evaluation evaluation)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Evaluation", evaluation);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Evaluation>();
        }

        public async Task<bool> DeleteEvaluation(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Evaluation/{id}");
            return response.IsSuccessStatusCode;
        }

        public void UpdateEvaluation(Evaluation evaluation)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvaluation(Task<Evaluation> evaluationToDelete)
        {
            throw new NotImplementedException();
        }
    }
}

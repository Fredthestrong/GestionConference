using GestionConf.Shared.Models;

namespace GestionConf.server.Services
{
    public interface IEvaluationService
    {
        Task<List<Evaluation>> GetAllEvaluations();
        Task<Evaluation> GetEvaluationById(int id);
        Task<Evaluation> AddEvaluation(Evaluation evaluation);
        Task<bool> DeleteEvaluation(int id);
        void UpdateEvaluation(Evaluation evaluation);
        void DeleteEvaluation(Task<Evaluation> evaluationToDelete);
    }
}

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionConf.server.Data;
//using GestionConf.server.Models;
using GestionConf.Shared.Models;

namespace GestionConf.server.Services
{
    public class EvaluationService : IEvaluationService
    {
        private readonly GestionConfDbContext _dbContext;


        public EvaluationService(GestionConfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Evaluation>> GetAllEvaluations()
        {
            var evaluations = await _dbContext.Evaluations.ToListAsync();
            return evaluations;
        }

        public async Task<Evaluation> GetEvaluationById(int id)
        {
            var evaluation = await _dbContext.Evaluations.FindAsync(id);
            return evaluation;
        }

        public async Task<Evaluation> AddEvaluation(Evaluation evaluation)
        {
            _dbContext.Evaluations.Add(evaluation);
            await _dbContext.SaveChangesAsync();
            return evaluation;
        }

        public async Task<bool> DeleteEvaluation(int id)
        {
            var evaluation = await _dbContext.Evaluations.FindAsync(id);
            if (evaluation == null)
            {
                return false;
            }

            _dbContext.Evaluations.Remove(evaluation);
            await _dbContext.SaveChangesAsync();
            return true;
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

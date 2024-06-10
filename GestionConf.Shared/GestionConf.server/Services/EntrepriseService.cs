using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionConf.server.Data;
//using GestionConf.server.Models;
using GestionConf.Shared.Models;

namespace GestionConf.server.Services
{
    public class EntrepriseService : IEntrepriseService
    {
        private readonly GestionConfDbContext _dbContext;


        public EntrepriseService(GestionConfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Entreprise>> GetAllEntreprises()
        {
            var entreprises = await _dbContext.Entreprises.ToListAsync();
            return entreprises;
        }

        public async Task<Entreprise> GetEntrepriseById(int id)
        {
            var entreprise = await _dbContext.Entreprises.FindAsync(id);
            return entreprise;
        }

        public async Task<Entreprise> AddEntreprise(Entreprise entreprise)
        {
            _dbContext.Entreprises.Add(entreprise);
            await _dbContext.SaveChangesAsync();
            return entreprise;
        }

        public async Task<bool> DeleteEntreprise(int id)
        {
            var entreprise = await _dbContext.Entreprises.FindAsync(id);
            if (entreprise == null)
            {
                return false;
            }

            _dbContext.Entreprises.Remove(entreprise);
            await _dbContext.SaveChangesAsync();
            return true;
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

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionConf.server.Data;
//using GestionConf.server.Models;
using GestionConf.Shared.Models;

namespace GestionConf.server.Services
{
    public class RelecteurService : IRelecteurService
    {
        private readonly GestionConfDbContext _dbContext;


        public RelecteurService(GestionConfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Relecteur>> GetAllRelecteurs()
        {
            return await _dbContext.Relecteurs.ToListAsync();
        }

        public async Task<Relecteur> GetRelecteurById(int id)
        {
            return await _dbContext.Relecteurs.FindAsync(id);
        }

        public async Task<Relecteur> AddRelecteur(Relecteur relecteur)
        {
            _dbContext.Relecteurs.Add(relecteur);
            await _dbContext.SaveChangesAsync();
            return relecteur;
        }

        public async Task<bool> DeleteRelecteur(int id)
        {
            var relecteur = await _dbContext.Relecteurs.FindAsync(id);
            if (relecteur == null)
            {
                return false;
            }

            _dbContext.Relecteurs.Remove(relecteur);
            await _dbContext.SaveChangesAsync();
            return true;
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

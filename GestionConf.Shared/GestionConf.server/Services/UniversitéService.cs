using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionConf.server.Data;
//using GestionConf.server.Models;
using GestionConf.Shared.Models;

namespace GestionConf.server.Services
{
    public class UniversitéService : IUniversitéService
    {
        private readonly GestionConfDbContext _dbContext;

        public UniversitéService(GestionConfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Université>> GetAllUniversités()
        {
            var universités = await _dbContext.Universités.ToListAsync();
            return universités;
        }

        public async Task<Université> GetUniversitéById(int id)
        {
            var université = await _dbContext.Universités.FindAsync(id);
            return université;
        }

        public async Task<Université> AddUniversité(Université université)
        {
            _dbContext.Universités.Add(université);
            await _dbContext.SaveChangesAsync();
            return université;
        }

        public async Task<bool> DeleteUniversité(int id)
        {
            var université = await _dbContext.Universités.FindAsync(id);
            if (université == null)
            {
                return false;
            }

            _dbContext.Universités.Remove(université);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void UpdateUniversité(Université université)
        {
            throw new NotImplementedException();
        }

        public void DeleteUniversité(Task<Université> universitéToDelete)
        {
            throw new NotImplementedException();
        }
    }
}

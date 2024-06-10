using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using GestionConf.server.Data;
//using GestionConf.server.Models;
using GestionConf.Shared.Models;

namespace GestionConf.server.Services
{
    public class AuteurService : IAuteurService
    {
        private readonly GestionConfDbContext _dbContext;


        public AuteurService(GestionConfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Auteur>> GetAllAuteurs()
        {
            var auteurs = await _dbContext.Auteurs.ToListAsync();
            return auteurs;
        }

        public async Task<Auteur> GetAuteurById(int id)
        {
            var auteur = await _dbContext.Auteurs.FindAsync(id);
            return auteur;
        }

        public async Task<Auteur> AddAuteur(Auteur auteur)
        {
            _dbContext.Auteurs.Add(auteur);
            await _dbContext.SaveChangesAsync();
            return auteur;
        }

        public async Task<bool> DeleteAuteur(int id)
        {
            var auteur = await _dbContext.Auteurs.FindAsync(id);
            if (auteur == null)
            {
                return false;
            }

            _dbContext.Auteurs.Remove(auteur);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public Task<bool> UpdateAuteur(Auteur auteur)
        {
            throw new NotImplementedException();
        }
    }
}

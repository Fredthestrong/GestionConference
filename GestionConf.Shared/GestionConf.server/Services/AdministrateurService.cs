//namespace GestionConf.server.Services
//{
//    public class AdministrateurService
//    {
//    }
//}

//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading.Tasks;
//using GestionConf.server.Data;
////using GestionConf.server.Models;
//using GestionConf.Shared.Models;

//namespace GestionConf.server.Services
//{
//    public class AdministrateurService : IAdministrateurService
//    {
//        private readonly GestionConfDbContext _dbContext;

//        public AdministrateurService(GestionConfDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<List<Administrateur>> GetAllAdmin()
//        {
//            var admins = await _dbContext.Administrateurs.ToListAsync();
//            return admins;
//        }

//        public async Task<Administrateur> GetAdminByEmail(string email)
//        {
//            var admin = await _dbContext.Administrateurs.FirstOrDefaultAsync(a => a.Email == email);
//            return admin;
//        }

//        public async Task<Administrateur> Enregistrer(Administrateur administrateur)
//        {
//            _dbContext.Administrateurs.Add(administrateur);
//            await _dbContext.SaveChangesAsync();
//            return administrateur;
//        }

//        public async Task<bool> DeleteAdmin(string email)
//        {
//            var admin = await _dbContext.Administrateurs.FindAsync(email);
//            if (admin == null)
//            {
//                return false;
//            }

//            _dbContext.Administrateurs.Remove(admin);
//            await _dbContext.SaveChangesAsync();

//            return true;
//        }
//    }
//}

using GestionConf.server.Data;
using GestionConf.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionConf.server.Services
{
    public class AdministrateurService : IAdministrateurService
    {
        private readonly GestionConfDbContext _dbContext;

        public AdministrateurService(GestionConfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Administrateur>> GetAllAdministrateurs()
        {
            return await _dbContext.Administrateurs.ToListAsync();
        }

        public async Task<Administrateur> GetAdministrateurById(int id)
        {
            return await _dbContext.Administrateurs.FindAsync(id);
        }

        public async Task<Administrateur> GetAdminByEmail(string email)
        {
            return await _dbContext.Administrateurs.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Administrateur> Enregistrer(Administrateur administrateur)
        {
            var result = _dbContext.Administrateurs.Add(administrateur);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAdmin(string email)
        {
            var administrateur = await _dbContext.Administrateurs.FirstOrDefaultAsync(a => a.Email == email);
            if (administrateur == null)
            {
                return false;
            }

            _dbContext.Administrateurs.Remove(administrateur);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Administrateur> AddAdministrateur(Administrateur administrateur)
        {
            _dbContext.Administrateurs.Add(administrateur);
            await _dbContext.SaveChangesAsync();
            return administrateur;
        }

        public async Task UpdateAdministrateur(Administrateur administrateur)
        {
            _dbContext.Administrateurs.Update(administrateur);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAdministrateur(int id)
        {
            var administrateur = await _dbContext.Administrateurs.FindAsync(id);
            if (administrateur == null)
            {
                return false;
            }

            _dbContext.Administrateurs.Remove(administrateur);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}



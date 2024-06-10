//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using GestionConf.server.Data;
////using GestionConf.server.Models;
//using GestionConf.Shared.Models;

//namespace GestionConf.server.Services
//{
//    public class ConférenceService : IConférenceService
//    {
//        private readonly GestionConfDbContext        _dbContext;

//        public ConférenceService(GestionConfDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<List<Conférence>> GetAllConférences()
//        {
//            var conférences = await _dbContext.Conférences.ToListAsync();
//            return conférences;
//        }

//        public async Task<Conférence> GetConférenceById(int id)
//        {
//            var conférence = await _dbContext.Conférences.FindAsync(id);
//            return conférence;
//        }

//        public async Task<Conférence> AddConférence(Conférence conférence)
//        {
//            _dbContext.Conférences.Add(conférence);
//            await _dbContext.SaveChangesAsync();
//            return conférence;
//        }

//        public async Task<bool> DeleteConférence(int id)
//        {
//            var conférence = await _dbContext.Conférences.FindAsync(id);
//            if (conférence == null)
//            {
//                return false;
//            }

//            _dbContext.Conférences.Remove(conférence);
//            await _dbContext.SaveChangesAsync();
//            return true;
//        }
//    }
//}

using GestionConf.server.Data;
using GestionConf.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestionConf.server.Services
{
    public class ConférenceService : IConférenceService
    {
        private readonly GestionConfDbContext _dbContext;

        public ConférenceService(GestionConfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Conférence>> GetAllConférences()
        {
            return await _dbContext.Conférences.ToListAsync();
        }

        public async Task<Conférence> GetConférenceById(int id)
        {
            return await _dbContext.Conférences.FindAsync(id);
        }

        public async Task<Conférence> AddConférence(Conférence conférence)
        {
            _dbContext.Conférences.Add(conférence);
            await _dbContext.SaveChangesAsync();
            return conférence;
        }

        public async Task<bool> UpdateConférence(Conférence conférence)
        {
            var existingConférence = await _dbContext.Conférences.FindAsync(conférence.IdConférence);
            if (existingConférence == null)
            {
                return false;
            }

            _dbContext.Entry(existingConférence).CurrentValues.SetValues(conférence);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteConférence(int id)
        {
            var conférence = await _dbContext.Conférences.FindAsync(id);
            if (conférence == null)
            {
                return false;
            }

            _dbContext.Conférences.Remove(conférence);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void DeleteConférence(Task<Conférence> conférenceToDelete)
        {
            throw new NotImplementedException();
        }
    }
}


using GestionConf.Shared.Models;
using System.Threading.Tasks;

namespace GestionConf.Client.Services
{
    public interface IConférenceService
    {
        Task<List<Conférence>> GetAllConférences();
        Task<Conférence> GetConférenceById(int id);
        Task<Conférence> AddConférence(Conférence conférence);
        Task<bool> UpdateConférence(Conférence conférence);
        Task<bool> DeleteConférence(int id);
        void DeleteConférence(Task<Conférence> conférenceToDelete);
    }
}


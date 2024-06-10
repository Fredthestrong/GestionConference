using GestionConf.Shared.Models;

namespace GestionConf.Client.Services
{
    public interface IUniversitéService
    {
        Task<List<Université>> GetAllUniversités();
        Task<Université> GetUniversitéById(int id);
        Task<Université> AddUniversité(Université université);
        Task<bool> DeleteUniversité(int id);
        void UpdateUniversité(Université université);
        void DeleteUniversité(Task<Université> universitéToDelete);
    }
}

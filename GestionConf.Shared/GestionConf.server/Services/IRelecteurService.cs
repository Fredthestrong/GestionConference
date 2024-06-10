using GestionConf.Shared.Models;

namespace GestionConf.server.Services
{
    public interface IRelecteurService
    {
        Task<List<Relecteur>> GetAllRelecteurs();
        Task<Relecteur> GetRelecteurById(int id);
        Task<Relecteur> AddRelecteur(Relecteur relecteur);
        Task<bool> DeleteRelecteur(int id);
        void DeleteRelecteur(Task<Relecteur> relecteurToDelete);
        void UpdateRelecteur(Relecteur relecteur);
    }
}

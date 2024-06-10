using GestionConf.Shared.Models;

namespace GestionConf.Client.Services
{
    public interface IEntrepriseService
    {
        Task<List<Entreprise>> GetAllEntreprises();
        Task<Entreprise> GetEntrepriseById(int id);
        Task<Entreprise> AddEntreprise(Entreprise entreprise);
        Task<bool> DeleteEntreprise(int id);
        void UpdateEntreprise(Entreprise entreprise);
        void DeleteEntreprise(Task<Entreprise> entrepriseToDelete);
    }
}

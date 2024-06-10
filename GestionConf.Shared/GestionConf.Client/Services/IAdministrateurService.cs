using GestionConf.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionConf.Client.Services
{
    public interface IAdministrateurService
    {
        Task<List<Administrateur>> GetAllAdministrateurs(); 
        Task<Administrateur> GetAdministrateurById(int id); 
        Task<Administrateur> GetAdminByEmail(string email);
        Task<Administrateur> Enregistrer(Administrateur administrateur);
        Task<bool> DeleteAdmin(string email);
        Task<Administrateur> AddAdministrateur(Administrateur administrateur); 
        Task UpdateAdministrateur(Administrateur administrateur); 
        Task<bool> DeleteAdministrateur(int id); 
    }
}


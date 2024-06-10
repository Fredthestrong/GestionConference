using GestionConf.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionConf.Client.Services
{
    public interface IAuteurService
    {
        Task<List<Auteur>> GetAllAuteurs();
        Task<Auteur> GetAuteurById(int id);
        Task<Auteur> AddAuteur(Auteur auteur);
        Task<bool> UpdateAuteur(Auteur auteur);
        Task<bool> DeleteAuteur(int id);
    }
}


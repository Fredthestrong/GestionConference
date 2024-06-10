using GestionConf.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionConf.server.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetAllArticles();
        Task<Article> GetArticleById(int id);
        Task<Article> AddArticle(Article article);
        Task<bool> DeleteArticle(int id);
        Task UpdateArticle(Article article); 
    }
}

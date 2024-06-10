////namespace GestionConf.server.Services
////{
////    public class ArticleService
////    {
////    }
////}

//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading.Tasks;
//using GestionConf.server.Data;
////using GestionConf.server.Models;
//using GestionConf.Shared.Models;

//namespace GestionConf.server.Services
//{
//    public class ArticleService : IArticleService
//    {
//        private readonly GestionConfDbContext _dbContext;

//        public ArticleService(GestionConfDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<List<Article>> GetAllArticles()
//        {
//            var articles = await _dbContext.Articles.ToListAsync();
//            return articles;
//        }

//        public async Task<Article> GetArticleById(int id)
//        {
//            var article = await _dbContext.Articles.FindAsync(id);
//            return article;
//        }

//        public async Task<Article> AddArticle(Article article)
//        {
//            _dbContext.Articles.Add(article);
//            await _dbContext.SaveChangesAsync();
//            return article;
//        }

//        public async Task<bool> DeleteArticle(int id)
//        {
//            var article = await _dbContext.Articles.FindAsync(id);
//            if (article == null)
//            {
//                return false;
//            }

//            _dbContext.Articles.Remove(article);
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
    public class ArticleService : IArticleService
    {
        private readonly GestionConfDbContext _dbContext;

        public ArticleService(GestionConfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Article>> GetAllArticles()
        {
            return await _dbContext.Articles.ToListAsync();
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await _dbContext.Articles.FindAsync(id);
        }

        public async Task<Article> AddArticle(Article article)
        {
            _dbContext.Articles.Add(article);
            await _dbContext.SaveChangesAsync();
            return article;
        }

        public async Task<bool> DeleteArticle(int id)
        {
            var article = await _dbContext.Articles.FindAsync(id);
            if (article == null)
            {
                return false;
            }

            _dbContext.Articles.Remove(article);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task UpdateArticle(Article article)
        {
            _dbContext.Articles.Update(article);
            await _dbContext.SaveChangesAsync();
        }
    }
}


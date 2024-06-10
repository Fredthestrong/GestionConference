//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace GestionConf.server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ArticleController : ControllerBase
//    {
//        // GET: api/<ArticleController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<ArticleController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<ArticleController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<ArticleController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<ArticleController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}

//using GestionConf.server.Services;
//using GestionConf.Shared.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;

//namespace GestionConf.server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ArticleController : ControllerBase
//    {
//        // Service pour la gestion des articles
//        private readonly IArticleService _articleService;

//        public ArticleController(IArticleService articleService)
//        {
//            _articleService = articleService;
//        }

//        // GET: api/<ArticleController>
//        [HttpGet]
//        public IEnumerable<Article> GetArticles()
//        {
//            return _articleService.GetAllArticles();
//        }

//        // GET api/<ArticleController>/5
//        [HttpGet("{id}")]
//        public ActionResult<Article> GetArticle(int id)
//        {
//            var article = _articleService.GetArticleById(id);
//            if (article == null)
//            {
//                return NotFound();
//            }
//            return article;
//        }

//        // POST api/<ArticleController>
//        [HttpPost]
//        public ActionResult<Article> CreateArticle(Article article)
//        {
//            _articleService.AddArticle(article);
//            return CreatedAtAction(nameof(GetArticle), new { id = article.Id }, article);
//        }

//        // PUT api/<ArticleController>/5
//        [HttpPut("{id}")]
//        public IActionResult UpdateArticle(int id, Article article)
//        {
//            if (id != article.Id)
//            {
//                return BadRequest();
//            }

//            try
//            {
//                _articleService.UpdateArticle(article);
//            }
//            catch (Exception)
//            {
//                return NotFound();
//            }

//            return NoContent();
//        }

//        // DELETE api/<ArticleController>/5
//        [HttpDelete("{id}")]
//        public IActionResult DeleteArticle(int id)
//        {
//            var articleToDelete = _articleService.GetArticleById(id);
//            if (articleToDelete == null)
//            {
//                return NotFound();
//            }
//            _articleService.DeleteArticle(articleToDelete);
//            return NoContent();
//        }
//    }
//}

using GestionConf.server.Services;
using GestionConf.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionConf.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _articleService.GetAllArticles();
        }

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _articleService.GetArticleById(id);
            if (article == null)
            {
                return NotFound();
            }
            return article;
        }

        // POST api/<ArticleController>
        [HttpPost]
        public async Task<ActionResult<Article>> CreateArticle(Article article)
        {
            await _articleService.AddArticle(article);
            return CreatedAtAction(nameof(GetArticle), new { id = article.IdArticle }, article);
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, Article article)
        {
            if (id != article.IdArticle)
            {
                return BadRequest();
            }

            try
            {
                await _articleService.UpdateArticle(article);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var articleToDelete = await _articleService.GetArticleById(id);
            if (articleToDelete == null)
            {
                return NotFound();
            }
            await _articleService.DeleteArticle(id);
            return NoContent();
        }
    }
}


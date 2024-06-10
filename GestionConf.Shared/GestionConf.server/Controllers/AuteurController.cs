////using Microsoft.AspNetCore.Mvc;

////// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

////namespace GestionConf.server.Controllers
////{
////    [Route("api/[controller]")]
////    [ApiController]
////    public class AuteurController : ControllerBase
////    {
////        // GET: api/<AuteurController>
////        [HttpGet]
////        public IEnumerable<string> Get()
////        {
////            return new string[] { "value1", "value2" };
////        }

////        // GET api/<AuteurController>/5
////        [HttpGet("{id}")]
////        public string Get(int id)
////        {
////            return "value";
////        }

////        // POST api/<AuteurController>
////        [HttpPost]
////        public void Post([FromBody] string value)
////        {
////        }

////        // PUT api/<AuteurController>/5
////        [HttpPut("{id}")]
////        public void Put(int id, [FromBody] string value)
////        {
////        }

////        // DELETE api/<AuteurController>/5
////        [HttpDelete("{id}")]
////        public void Delete(int id)
////        {
////        }
////    }
////}

//using GestionConf.server.Services;
//using GestionConf.Shared.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;

//namespace GestionConf.server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuteurController : ControllerBase
//    {
//        // Service pour la gestion des auteurs
//        private readonly IAuteurService _auteurService;

//        public AuteurController(IAuteurService auteurService)
//        {
//            _auteurService = auteurService;
//        }

//        // GET: api/<AuteurController>
//        [HttpGet]
//        public IEnumerable<Auteur> GetAuteurs()
//        {
//            return _auteurService.GetAllAuteurs();
//        }

//        // GET api/<AuteurController>/5
//        [HttpGet("{id}")]
//        public ActionResult<Auteur> GetAuteur(int id)
//        {
//            var auteur = _auteurService.GetAuteurById(id);
//            if (auteur == null)
//            {
//                return NotFound();
//            }
//            return auteur;
//        }

//        // POST api/<AuteurController>
//        [HttpPost]
//        public ActionResult<Auteur> CreateAuteur(Auteur auteur)
//        {
//            _auteurService.AddAuteur(auteur);
//            return CreatedAtAction(nameof(GetAuteur), new { id = auteur.Id }, auteur);
//        }

//        // PUT api/<AuteurController>/5
//        [HttpPut("{id}")]
//        public IActionResult UpdateAuteur(int id, Auteur auteur)
//        {
//            if (id != auteur.Id)
//            {
//                return BadRequest();
//            }

//            try
//            {
//                _auteurService.UpdateAuteur(auteur);
//            }
//            catch (Exception)
//            {
//                return NotFound();
//            }

//            return NoContent();
//        }

//        // DELETE api/<AuteurController>/5
//        [HttpDelete("{id}")]
//        public IActionResult DeleteAuteur(int id)
//        {
//            var auteurToDelete = _auteurService.GetAuteurById(id);
//            if (auteurToDelete == null)
//            {
//                return NotFound();
//            }
//            _auteurService.DeleteAuteur(auteurToDelete);
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
    public class AuteurController : ControllerBase
    {
        private readonly IAuteurService _auteurService;

        public AuteurController(IAuteurService auteurService)
        {
            _auteurService = auteurService;
        }

        // GET: api/<AuteurController>
        [HttpGet]
        public async Task<IEnumerable<Auteur>> GetAuteurs()
        {
            return await _auteurService.GetAllAuteurs();
        }

        // GET api/<AuteurController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auteur>> GetAuteur(int id)
        {
            var auteur = await _auteurService.GetAuteurById(id);
            if (auteur == null)
            {
                return NotFound();
            }
            return auteur;
        }

        // POST api/<AuteurController>
        [HttpPost]
        public async Task<ActionResult<Auteur>> CreateAuteur(Auteur auteur)
        {
            await _auteurService.AddAuteur(auteur);
            return CreatedAtAction(nameof(GetAuteur), new { id = auteur.IdAuteur }, auteur);
        }

        // PUT api/<AuteurController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuteur(int id, Auteur auteur)
        {
            if (id != auteur.IdAuteur)
            {
                return BadRequest();
            }

            try
            {
                await _auteurService.UpdateAuteur(auteur);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<AuteurController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuteur(int id)
        {
            var auteurToDelete = await _auteurService.GetAuteurById(id);
            if (auteurToDelete == null)
            {
                return NotFound();
            }
            await _auteurService.DeleteAuteur(id);
            return NoContent();
        }
    }
}


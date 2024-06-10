////using Microsoft.AspNetCore.Mvc;

////// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

////namespace GestionConf.server.Controllers
////{
////    [Route("api/[controller]")]
////    [ApiController]
////    public class AdministrateurController : ControllerBase
////    {
////        // GET: api/<AdministrateurController>
////        [HttpGet]
////        public IEnumerable<string> Get()
////        {
////            return new string[] { "value1", "value2" };
////        }

////        // GET api/<AdministrateurController>/5
////        [HttpGet("{id}")]
////        public string Get(int id)
////        {
////            return "value";
////        }

////        // POST api/<AdministrateurController>
////        [HttpPost]
////        public void Post([FromBody] string value)
////        {
////        }

////        // PUT api/<AdministrateurController>/5
////        [HttpPut("{id}")]
////        public void Put(int id, [FromBody] string value)
////        {
////        }

////        // DELETE api/<AdministrateurController>/5
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
//    public class AdministrateurController : ControllerBase
//    {
//        // Service pour la gestion des administrateurs
//        private readonly IAdministrateurService _administrateurService;

//        public AdministrateurController(IAdministrateurService administrateurService)
//        {
//            _administrateurService = administrateurService;
//        }

//        // GET: api/<AdministrateurController>
//        [HttpGet]
//        public IEnumerable<Administrateur> GetAdministrateurs()
//        {
//            return _administrateurService.GetAllAdministrateurs();
//        }

//        // GET api/<AdministrateurController>/5
//        [HttpGet("{id}")]
//        public ActionResult<Administrateur> GetAdministrateur(int id)
//        {
//            var administrateur = _administrateurService.GetAdministrateurById(id);
//            if (administrateur == null)
//            {
//                return NotFound();
//            }
//            return administrateur;
//        }

//        // POST api/<AdministrateurController>
//        [HttpPost]
//        public ActionResult<Administrateur> CreateAdministrateur(Administrateur administrateur)
//        {
//            _administrateurService.AddAdministrateur(administrateur);
//            return CreatedAtAction(nameof(GetAdministrateur), new { id = administrateur.Id }, administrateur);
//        }

//        // PUT api/<AdministrateurController>/5
//        [HttpPut("{id}")]
//        public IActionResult UpdateAdministrateur(int id, Administrateur administrateur)
//        {
//            if (id != administrateur.Id)
//            {
//                return BadRequest();
//            }

//            try
//            {
//                _administrateurService.UpdateAdministrateur(administrateur);
//            }
//            catch (Exception)
//            {
//                return NotFound();
//            }

//            return NoContent();
//        }

//        // DELETE api/<AdministrateurController>/5
//        [HttpDelete("{id}")]
//        public IActionResult DeleteAdministrateur(int id)
//        {
//            var administrateurToDelete = _administrateurService.GetAdministrateurById(id);
//            if (administrateurToDelete == null)
//            {
//                return NotFound();
//            }
//            _administrateurService.DeleteAdministrateur(administrateurToDelete);
//            return NoContent();
//        }
//    }
//}


using GestionConf.server.Services;
using GestionConf.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionConf.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrateurController : ControllerBase
    {
        private readonly IAdministrateurService _administrateurService;

        public AdministrateurController(IAdministrateurService administrateurService)
        {
            _administrateurService = administrateurService;
        }

        // GET: api/<AdministrateurController>
        [HttpGet]
        public async Task<IEnumerable<Administrateur>> GetAdministrateurs()
        {
            return await _administrateurService.GetAllAdministrateurs();
        }

        // GET api/<AdministrateurController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrateur>> GetAdministrateur(int id)
        {
            var administrateur = await _administrateurService.GetAdministrateurById(id);
            if (administrateur == null)
            {
                return NotFound();
            }
            return administrateur;
        }

        // POST api/<AdministrateurController>
        [HttpPost]
        public async Task<ActionResult<Administrateur>> CreateAdministrateur(Administrateur administrateur)
        {
            await _administrateurService.AddAdministrateur(administrateur);
            return CreatedAtAction(nameof(GetAdministrateur), new { id = administrateur.IdAdmin }, administrateur);
        }

        // PUT api/<AdministrateurController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdministrateur(int id, Administrateur administrateur)
        {
            if (id != administrateur.IdAdmin)
            {
                return BadRequest();
            }

            try
            {
                await _administrateurService.UpdateAdministrateur(administrateur);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _administrateurService.GetAdministrateurById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<AdministrateurController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrateur(int id)
        {
            var administrateurToDelete = await _administrateurService.GetAdministrateurById(id);
            if (administrateurToDelete == null)
            {
                return NotFound();
            }
            await _administrateurService.DeleteAdministrateur(id);
            return NoContent();
        }
    }
}


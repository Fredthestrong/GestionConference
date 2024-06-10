//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace GestionConf.server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EntrepriseController : ControllerBase
//    {
//        // GET: api/<EntrepriseController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<EntrepriseController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<EntrepriseController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<EntrepriseController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<EntrepriseController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}

using GestionConf.server.Services;
using GestionConf.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GestionConf.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrepriseController : ControllerBase
    {
        // Service pour la gestion des entreprises
        private readonly IEntrepriseService _entrepriseService;

        public EntrepriseController(IEntrepriseService entrepriseService)
        {
            _entrepriseService = entrepriseService;
        }

        //// GET: api/<EntrepriseController>
        //[HttpGet]
        //public IEnumerable<Entreprise> GetEntreprises()
        //{
        //    return _entrepriseService.GetAllEntreprises();
        //}
        // GET: api/<EntrepriseController>
        [HttpGet]
        public async Task<IEnumerable<Entreprise>> GetEntreprises()
        {
            var entreprises = await _entrepriseService.GetAllEntreprises();
            return entreprises;
        }


        //// GET api/<EntrepriseController>/5
        //[HttpGet("{id}")]
        //public ActionResult<Entreprise> GetEntreprise(int id)
        //{
        //    var entreprise = _entrepriseService.GetEntrepriseById(id);
        //    if (entreprise == null)
        //    {
        //        return NotFound();
        //    }
        //    return entreprise;
        //}
        // GET api/<EntrepriseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entreprise>> GetEntreprise(int id)
        {
            var entreprise = await _entrepriseService.GetEntrepriseById(id);
            if (entreprise == null)
            {
                return NotFound();
            }
            return entreprise;
        }



        // POST api/<EntrepriseController>
        [HttpPost]
        public ActionResult<Entreprise> CreateEntreprise(Entreprise entreprise)
        {
            _entrepriseService.AddEntreprise(entreprise);
            return CreatedAtAction(nameof(GetEntreprise), new { id = entreprise.IdEntreprise }, entreprise);
        }

        // PUT api/<EntrepriseController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateEntreprise(int id, Entreprise entreprise)
        {
            if (id != entreprise.IdEntreprise)
            {
                return BadRequest();
            }

            try
            {
                _entrepriseService.UpdateEntreprise(entreprise);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<EntrepriseController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEntreprise(int id)
        {
            var entrepriseToDelete = _entrepriseService.GetEntrepriseById(id);
            if (entrepriseToDelete == null)
            {
                return NotFound();
            }
            _entrepriseService.DeleteEntreprise(entrepriseToDelete);
            return NoContent();
        }
    }
}


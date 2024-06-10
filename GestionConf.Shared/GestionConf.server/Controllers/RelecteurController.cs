using GestionConf.server.Services;
using GestionConf.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GestionConf.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelecteurController : ControllerBase
    {
        // Service pour la gestion des relecteurs
        private readonly IRelecteurService _relecteurService;

        public RelecteurController(IRelecteurService relecteurService)
        {
            _relecteurService = relecteurService;
        }

        //// GET: api/<RelecteurController>
        //[HttpGet]
        //public IEnumerable<Relecteur> GetRelecteurs()
        //{
        //    return _relecteurService.GetAllRelecteurs();
        //}
        // GET: api/<RelecteurController>
        [HttpGet]
        public async Task<IEnumerable<Relecteur>> GetRelecteurs()
        {
            var relecteurs = await _relecteurService.GetAllRelecteurs();
            return relecteurs;
        }


        //// GET api/<RelecteurController>/5
        //[HttpGet("{id}")]
        //public ActionResult<Relecteur> GetRelecteur(int id)
        //{
        //    var relecteur = _relecteurService.GetRelecteurById(id);
        //    if (relecteur == null)
        //    {
        //        return NotFound();
        //    }
        //    return relecteur;
        //}
        // GET api/<RelecteurController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Relecteur>> GetRelecteur(int id)
        {
            var relecteur = await _relecteurService.GetRelecteurById(id);
            if (relecteur == null)
            {
                return NotFound();
            }
            return relecteur;
        }



        // POST api/<RelecteurController>
        [HttpPost]
        public ActionResult<Relecteur> CreateRelecteur(Relecteur relecteur)
        {
            _relecteurService.AddRelecteur(relecteur);
            return CreatedAtAction(nameof(GetRelecteur), new { id = relecteur.IdRelecteur }, relecteur);
        }

        // PUT api/<RelecteurController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateRelecteur(int id, Relecteur relecteur)
        {
            if (id != relecteur.IdRelecteur)
            {
                return BadRequest();
            }

            try
            {
                _relecteurService.UpdateRelecteur(relecteur);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<RelecteurController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRelecteur(int id)
        {
            var relecteurToDelete = _relecteurService.GetRelecteurById(id);
            if (relecteurToDelete == null)
            {
                return NotFound();
            }
            _relecteurService.DeleteRelecteur(relecteurToDelete);
            return NoContent();
        }
    }
}


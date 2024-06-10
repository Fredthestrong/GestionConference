using GestionConf.server.Services;
using GestionConf.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GestionConf.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitéController : ControllerBase
    {
        // Service pour la gestion des universités
        private readonly IUniversitéService _universitéService;

        public UniversitéController(IUniversitéService universitéService)
        {
            _universitéService = universitéService;
        }

        //// GET: api/<UniversitéController>
        //[HttpGet]
        //public IEnumerable<Université> GetUniversités()
        //{
        //    return _universitéService.GetAllUniversités();
        //}
        // GET: api/<UniversitéController>
        [HttpGet]
        public async Task<IEnumerable<Université>> GetUniversités()
        {
            var universités = await _universitéService.GetAllUniversités();
            return universités;
        }


        //// GET api/<UniversitéController>/5
        //[HttpGet("{id}")]
        //public ActionResult<Université> GetUniversité(int id)
        //{
        //    var université = _universitéService.GetUniversitéById(id);
        //    if (université == null)
        //    {
        //        return NotFound();
        //    }
        //    return université;
        //}
        // GET api/<UniversitéController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Université>> GetUniversité(int id)
        {
            var université = await _universitéService.GetUniversitéById(id);
            if (université == null)
            {
                return NotFound();
            }
            return université;
        }



        // POST api/<UniversitéController>
        [HttpPost]
        public ActionResult<Université> CreateUniversité(Université université)
        {
            _universitéService.AddUniversité(université);
            return CreatedAtAction(nameof(GetUniversité), new { id = université.IdUniversité }, université);
        }

        // PUT api/<UniversitéController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateUniversité(int id, Université université)
        {
            if (id != université.IdUniversité)
            {
                return BadRequest();
            }

            try
            {
                _universitéService.UpdateUniversité(université);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<UniversitéController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUniversité(int id)
        {
            var universitéToDelete = _universitéService.GetUniversitéById(id);
            if (universitéToDelete == null)
            {
                return NotFound();
            }
            _universitéService.DeleteUniversité(universitéToDelete);
            return NoContent();
        }
    }
}


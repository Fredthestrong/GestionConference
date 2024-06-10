//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace GestionConf.server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ConférenceController : ControllerBase
//    {
//        // GET: api/<ConférenceController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<ConférenceController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<ConférenceController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<ConférenceController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<ConférenceController>/5
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
    public class ConférenceController : ControllerBase
    {
        // Service pour la gestion des conférences
        private readonly IConférenceService _conférenceService;

        public ConférenceController(IConférenceService conférenceService)
        {
            _conférenceService = conférenceService;
        }

        //// GET: api/<ConférenceController>
        //[HttpGet]
        //public IEnumerable<Conférence> GetConférences()
        //{
        //    return _conférenceService.GetAllConférences();
        //}

        // GET: api/<ConférenceController>
        [HttpGet]
        public async Task<IEnumerable<Conférence>> GetConférences()
        {
            var conférences = await _conférenceService.GetAllConférences();
            return conférences;
        }


        //// GET api/<ConférenceController>/5
        //[HttpGet("{id}")]
        //public ActionResult<Conférence> GetConférence(int id)
        //{
        //    var conférence = _conférenceService.GetConférenceById(id);
        //    if (conférence == null)
        //    {
        //        return NotFound();
        //    }
        //    return conférence;
        //}
        // GET api/<ConférenceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conférence>> GetConférence(int id)
        {
            var conférence = await _conférenceService.GetConférenceById(id);
            if (conférence == null)
            {
                return NotFound();
            }
            return Ok(conférence);
        }



        // POST api/<ConférenceController>
        [HttpPost]
        public ActionResult<Conférence> CreateConférence(Conférence conférence)
        {
            _conférenceService.AddConférence(conférence);
            return CreatedAtAction(nameof(GetConférence), new { id = conférence.IdConférence }, conférence);
        }

        // PUT api/<ConférenceController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateConférence(int id, Conférence conférence)
        {
            if (id != conférence.IdConférence)
            {
                return BadRequest();
            }

            try
            {
                _conférenceService.UpdateConférence(conférence);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<ConférenceController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteConférence(int id)
        {
            var conférenceToDelete = _conférenceService.GetConférenceById(id);
            if (conférenceToDelete == null)
            {
                return NotFound();
            }
            _conférenceService.DeleteConférence(conférenceToDelete);
            return NoContent();
        }
    }
}


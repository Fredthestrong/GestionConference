//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace GestionConf.server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ParticipantController : ControllerBase
//    {
//        // GET: api/<ParticipantController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<ParticipantController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<ParticipantController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<ParticipantController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<ParticipantController>/5
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
    public class ParticipantController : ControllerBase
    {
        // Service pour la gestion des participants
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        //// GET: api/<ParticipantController>
        //[HttpGet]
        //public IEnumerable<Participant> GetParticipants()
        //{
        //    return _participantService.GetAllParticipants();
        //}
        // GET: api/<ParticipantController>
        [HttpGet]
        public async Task<IEnumerable<Participant>> GetParticipants()
        {
            var participants = await _participantService.GetAllParticipants();
            return participants;
        }



        //// GET api/<ParticipantController>/5
        //[HttpGet("{id}")]
        //public ActionResult<Participant> GetParticipant(int id)
        //{
        //    var participant = _participantService.GetParticipantById(id);
        //    if (participant == null)
        //    {
        //        return NotFound();
        //    }
        //    return participant;
        //}
        // GET api/<ParticipantController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipant(int id)
        {
            var participant = await _participantService.GetParticipantById(id);
            if (participant == null)
            {
                return NotFound();
            }
            return participant;
        }



        // POST api/<ParticipantController>
        [HttpPost]
        public ActionResult<Participant> CreateParticipant(Participant participant)
        {
            _participantService.AddParticipant(participant);
            return CreatedAtAction(nameof(GetParticipant), new { id = participant.IdParticipant }, participant);
        }

        // PUT api/<ParticipantController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateParticipant(int id, Participant participant)
        {
            if (id != participant.IdParticipant)
            {
                return BadRequest();
            }

            try
            {
                _participantService.UpdateParticipant(participant);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<ParticipantController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteParticipant(int id)
        {
            var participantToDelete = _participantService.GetParticipantById(id);
            if (participantToDelete == null)
            {
                return NotFound();
            }
            _participantService.DeleteParticipant(participantToDelete);
            return NoContent();
        }
    }
}


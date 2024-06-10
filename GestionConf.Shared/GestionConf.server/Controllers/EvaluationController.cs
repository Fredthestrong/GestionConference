//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace GestionConf.server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EvaluationController : ControllerBase
//    {
//        // GET: api/<EvaluationController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<EvaluationController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<EvaluationController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<EvaluationController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<EvaluationController>/5
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
    public class EvaluationController : ControllerBase
    {
        // Service pour la gestion des évaluations
        private readonly IEvaluationService _evaluationService;

        public EvaluationController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        //// GET: api/<EvaluationController>
        //[HttpGet]
        //public IEnumerable<Evaluation> GetEvaluations()
        //{
        //    return _evaluationService.GetAllEvaluations();
        //}


        //// GET api/<EvaluationController>/5
        //[HttpGet("{id}")]
        //public ActionResult<Evaluation> GetEvaluation(int id)
        //{
        //    var evaluation = _evaluationService.GetEvaluationById(id);
        //    if (evaluation == null)
        //    {
        //        return NotFound();
        //    }
        //    return evaluation;
        //}
        // GET api/<EvaluationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evaluation>> GetEvaluation(int id)
        {
            var evaluation = await _evaluationService.GetEvaluationById(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            return evaluation;
        }



        // POST api/<EvaluationController>
        [HttpPost]
        public ActionResult<Evaluation> CreateEvaluation(Evaluation evaluation)
        {
            _evaluationService.AddEvaluation(evaluation);
            return CreatedAtAction(nameof(GetEvaluation), new { id = evaluation.IdEvaluation }, evaluation);
        }

        // PUT api/<EvaluationController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateEvaluation(int id, Evaluation evaluation)
        {
            if (id != evaluation.IdEvaluation)
            {
                return BadRequest();
            }

            try
            {
                _evaluationService.UpdateEvaluation(evaluation);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<EvaluationController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEvaluation(int id)
        {
            var evaluationToDelete = _evaluationService.GetEvaluationById(id);
            if (evaluationToDelete == null)
            {
                return NotFound();
            }
            _evaluationService.DeleteEvaluation(evaluationToDelete);
            return NoContent();
        }
    }
}


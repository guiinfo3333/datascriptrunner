using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseScriptRunner.Domain.Entities;
using DatabaseScriptRunner.Infraestructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseScriptRunner.Api.Controllers
{
    [Route("api/action")]
    [ApiController]
    public class ActionUserController : ControllerBase
    {
      private readonly IDataRepository<ActionUser> _actionRepository;
        
        //private readonly ApplicationSettings _appSettings;
        

        public ActionUserController(IDataRepository<ActionUser> actionRepository)
        {
            _actionRepository = actionRepository;

        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ActionUser> actions = _actionRepository.GetAll();
            return Ok(actions);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            ActionUser actions = _actionRepository.Get(id);

            if (actions == null)
            {
                return NotFound("Não foi possível encontrar comando.");
            }

            return Ok(actions);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] ActionUser action)
        {
            if (action == null)
            {
                return BadRequest("Nenhum comando encontrado.");
            }

            _actionRepository.Add(action);
            return CreatedAtRoute(
                  "Get",
                  new { Id = action.IdAction },
                  action);
        }


        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            ActionUser action = _actionRepository.Get(id);
            if (action == null)
            {
                return NotFound("Nenhum comando encontrado.");
            }

            _actionRepository.Delete(action);
            return NoContent();
        }
    }
}
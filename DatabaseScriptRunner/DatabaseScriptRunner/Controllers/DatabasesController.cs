using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseScriptRunner.Domain.Entities;
using DatabaseScriptRunner.Infraestructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseScriptRunner.Api.Controllers
{
    [Route("api/databases")]
    [ApiController]
   [Authorize]
    public class DatabaseController : ControllerBase
    {
        private readonly IDataRepository<Database> _dataRepository;

        public DatabaseController(IDataRepository<Database> dataRepository)
        {
            _dataRepository = dataRepository;
        }

       
       //[HttpGet]
        //public IActionResult Get()    //get alterado para recuperar ultimo id
        //{
        //   Resultado databases = _dataRepository.ultimoId();
        //     return Ok(databases);
        //}

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)


    {
            List<Database> rr1 = new List<Database>();
            rr1 = _dataRepository.PegaBanco(id);

            if (rr1 == null)
            {
                return NotFound("Não foi possível encontrar esse Banco de Dados.");
            }

            return Ok(rr1);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Database database)
        {
            
            Resultado res = new Resultado();
            res.textresult = "banco adicionado com sucesso !";
            if (database.Name.Equals("") || database.ConnectionString.Equals(""))
            {
                res.textresult = "Preencha os campos necessários !";
                // return BadRequest("Nenhum Banco de Dados.");
            }
            _dataRepository.Add(database);
            Resultado resu = _dataRepository.ultimoId();

            res.UltimoId = Int32.Parse(resu.textresult);
            //  Resultado databases = _dataRepository.ultimoId();
            //  return CreatedAtRoute(
            //      "Get",
            //       new { Id = database.IdDatabase },
            //     database);
            return Ok(res);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Database database)
        {
            if (database == null)
            {
                return BadRequest("Nenhum Banco de Dados.");
            }

            Database databaseToUpdate = _dataRepository.Get(id);
            if (databaseToUpdate == null)
            {
                return NotFound("Nenhum Banco de Dados encontrado.");
            }

            _dataRepository.Update(databaseToUpdate, database);
            return NoContent();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Database database = _dataRepository.Get(id);
            if (database == null)
            {
                return NotFound("Nenhum Banco de Dados encontrado.");
            }

            _dataRepository.Delete(database);
            return NoContent();
        }
    }
}
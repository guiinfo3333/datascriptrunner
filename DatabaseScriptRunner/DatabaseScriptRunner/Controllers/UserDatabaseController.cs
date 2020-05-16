using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseScriptRunner.Domain.Entities;
using DatabaseScriptRunner.Infraestructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseScriptRunner.Api.Controllers
{
    [Route("api/addrelaction")]
    [ApiController]
   // [Authorize]
    public class UserDatabaseController : ControllerBase
    {
        private readonly IDataRepository<UserDatabase> _userRepository;

        //private readonly ApplicationSettings _appSettings;


        public UserDatabaseController(IDataRepository<UserDatabase> userRepository)
        {
            _userRepository = userRepository;

        }
        
        public IActionResult Post([FromBody] UserDatabase userd)
        {
            Resultado r1 = new Resultado();
            r1.textresult = "Banco de dados adicionado com sucesso !";
            if (userd == null)
            {
                return BadRequest("Nenhum relacao feita.");
            }
            else
            {
                _userRepository.Add(userd);
            }

            return Ok(r1);
          
        }
    }
}
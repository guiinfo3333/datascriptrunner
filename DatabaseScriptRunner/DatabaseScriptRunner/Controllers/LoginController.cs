using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseScriptRunner.Domain.Entities;
using DatabaseScriptRunner.Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseScriptRunner.Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IDataRepository<User> _userRepository;
        public LoginController(IDataRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult PostLogin([FromBody] User user)
        {

            bool oi = _userRepository.Login(user);


            return Ok(oi);
        }


    }
}

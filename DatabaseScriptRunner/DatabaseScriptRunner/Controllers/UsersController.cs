using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatabaseScriptRunner.Domain.Entities;
using DatabaseScriptRunner.Infraestructure.Data;
using DatabaseScriptRunner.Infraestructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DatabaseScriptRunner.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IDataRepository<User> _userRepository;
        
        //private readonly ApplicationSettings _appSettings;
        

        public UserController(IDataRepository<User> userRepository)
        {
            _userRepository = userRepository;

        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()


        {
            IEnumerable<User> users = _userRepository.GetAll();
            return Ok(users);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            User user = _userRepository.Get(id);

            if (user == null)
            {
                return NotFound("Não foi possível encontrar esse Perfil.");
            }

            return Ok(user);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            Resultado result = new Resultado();
            result.textresult = "Usuário cadastrado com sucesso !";
            if (user == null)
            {
                result.textresult = "Erro ao cadastrar usuário !";
            }

            _userRepository.Add(user);
            return Ok(result);
           
        }

                // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Nenhum Perfil encontrado.");
            }

            User userToUpdate = _userRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("Nenhum Perfil encontrado.");
            }

            _userRepository.Update(userToUpdate, user);
            return NoContent();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            User user = _userRepository.Get(id);
            if (user == null)
            {
                return NotFound("Nenhum Perfil encontrado.");
            }

            _userRepository.Delete(user);
            return NoContent();
        }

        // LOGIN
        //[HttpPost]
        //[Route("api/users/Login")]
        ////Post: /api/users/Login
        //public async Task<IActionResult> Login([FromBody] User user)
        //{
        //    var userLogin = await _userRepository.FindByNameAsync(user.Password);
        //    if (userLogin != null && await _userRepository.CheckPasswordAsync(userLogin, user.Password))
        //    {
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //            {
        //                new Claim("UserID", userLogin.Id.ToString())
        //            }),
        //            Expires = DateTime.UtcNow.AddMinutes(5),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
        //        };
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        //        var token = tokenHandler.WriteToken(securityToken);
        //        return Ok(new { token });
        //    }
        //    else
        //    {
        //        return BadRequest(new { message = "Login ou Senha incorreta." });
        //    }
        //}
    }
}
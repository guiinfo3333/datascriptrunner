using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatabaseScriptRunner.Domain.Entities;
using DatabaseScriptRunner.Infraestructure.DataManager;
using DatabaseScriptRunner.Infraestructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DatabaseScriptRunner.Api.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        
      
        private const string SECRET_KEY = "my_secret_key_forever";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenController.SECRET_KEY));


        private readonly IDataRepository<User> _userRepository;
        public TokenController(IDataRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Logar([FromBody] User user)
        {
            Resultado resu = new Resultado();
            if (_userRepository.Login(user))
            {
                User u = new User();
                u = _userRepository.Forname(user.Login);
                resu.iduser = u.IdUser;
                //   Set("Id",u.IdUser.ToString(), 1000);
                resu.textresult = GenerateToken(user).ToString();
                return Ok(resu);
            }
            else
            {
                resu.textresult = "Erro ao fazer login !";
                return Ok(resu);
            }
        }

        private object GenerateToken(User user)
        {
            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Login)
                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                signingCredentials: new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256)
                );
                return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string Get(string chave)
        {

            return Request.Cookies[chave];
        }

        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMinutes(60);
            Response.Cookies.Append(key, value, option);
        }

        public void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }
    }
}
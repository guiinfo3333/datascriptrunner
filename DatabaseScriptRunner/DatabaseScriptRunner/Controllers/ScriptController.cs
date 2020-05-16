using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseScriptRunner.Domain.Entities;
using DatabaseScriptRunner.Infraestructure.DataManager;
using DatabaseScriptRunner.Infraestructure.Repository;
using DatabaseScriptRunner.Infraestructure.RunnerScript;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseScriptRunner.Api.Controllers
{
    [Route("api/scripts")]
    [ApiController]
    //[Authorize]
    public class ScriptController : Controller
    {

        private readonly IDataRepository<ActionUser> _actionRepository;
        private readonly IDataRepository<Database> _databaseRepository;
        public ScriptController(IDataRepository<ActionUser> actionRepository, IDataRepository<Database> dataRepository)
        {
            _actionRepository = actionRepository;
            _databaseRepository = dataRepository;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Script script)
        {
         //  ActionUser action = new ActionUser();
            //action.IdAction = 32;
           // action.IdUser= Convert.ToInt32(Request.Cookies["Id"]);
          List<Resultado> r1 = new List<Resultado>();
            if (script == null)
            {

                return Ok("Adicione um objeto com características !");
            }
            else
            {
                // RODANDO O 'SCRIPT' EM TODOS OS BANCO
                foreach (var item in script.Databases)
                {
                    //metodo para procurar informacoes do database a partir do id

                    Database databasea = _databaseRepository.Get(item);

                    //fim do metodo

                    RunnerScript1 obj = new RunnerScript1(databasea.ConnectionString, databasea.Name);
                     r1.Add(obj.ExecuteAll(script));
                   // action.command = script.text;
                   // _actionRepository.Add(action);
                }
                return Ok(r1);
            }

         
        }

    }
}
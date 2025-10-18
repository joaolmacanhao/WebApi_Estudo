using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Estudo.Models;
using WebApi_Estudo.Service.FuncionarioService;

namespace WebApi_Estudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface) {
            _funcionarioInterface = funcionarioInterface;
        } 
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List <FuncionarioModel>>>> GetFuncionario()
        {
            return Ok(await _funcionarioInterface.GetFucionarios());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok (await _funcionarioInterface.CreatFucionarios(novoFuncionario));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int id)
        {
            return Ok(await _funcionarioInterface.GetFuncionarioById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionarioById(int id)
        {
            return Ok(await _funcionarioInterface.DeleteFucionarioById(id));
        }

        [HttpPatch("inativa/{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario(int id)
        {
            return Ok(await _funcionarioInterface.InativaFuncionario(id));
        }

        [HttpPatch("reativa/{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> ReativaFuncionario(int id)
        {
            return Ok(await _funcionarioInterface.RetivaFuncionario(id));
        }
    }
}

using Domin;
using Domin.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GerenciamentoTerefas.Controllers
{
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService) 
        {
            _projetoService = projetoService;
        }



        [HttpGet]
        [Route("api/v1/Projeto/BuscaTodosProjetosUsuario/{IdUsuario}")]
        public async Task<ActionResult> GetAll(long IdUsuario)
        {
            try
            {
                return Ok(await _projetoService.GetAllAsync(IdUsuario));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
                                                           
        [HttpGet]
        [Route("api/v1/Projeto/BuscaProjetosEspecifico/{Id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                //await _projetoService.GetByIdAsync(id);

                return Ok(await _projetoService.GetByIdAsync(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
                                                 
        [HttpDelete]
        [Route("api/v1/Projeto/RemoveProjeto/")]
        public async Task<ActionResult> Delete([FromHeader] long id)
        {
            try
            {
                if (await _projetoService.RemoveAsync(id))
                {
                    return Ok();
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "Existe Tarefas Pendentes. Conclua ou remova a terefa primeiro.");
                }

                
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("api/v1/Projeto/CriarProjeto")]
        public async Task<ActionResult> Add(ProjetoEntity projeto)
        {
            try
            {
                return Ok(await _projetoService.AddAsync(projeto));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}

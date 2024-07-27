using Domin.Entities;
using Domin.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GerenciamentoTerefas.Controllers
{
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }


        [HttpGet]
        [Route("api/v1/Tarefa/BuscaTodasTarefasProjeto/{IdProjeto}")]
        public async Task<ActionResult> Get(long IdProjeto)
        {
            try
            {
                return Ok(await _tarefaService.GetByProjetoIdAsync(IdProjeto));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("api/v1/Tarefa/CriarTarefa")]
        public async Task<ActionResult> Add(TarefaEntity tarefa)
        {
            try
            {
                var result = await _tarefaService.AddAsync(tarefa);
                if (result == null)
                    return StatusCode((int)HttpStatusCode.BadRequest, "Ultrapassou o limite de 20 tarefa por projeto.");

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("api/v1/Tarefa/AtualizaTarefa/{comentario}/{IdUusuario}")]
        public async Task<ActionResult> Update(TarefaEntity projeto, string comentario, long IdUusuario)
        {
            try
            {
                await _tarefaService.UpdateAsync(projeto, comentario, IdUusuario);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("api/v1/Tarefa/RemoveTarefa/{Id}")]
        public async Task<ActionResult> Delete(long Id)
        {
            try
            {
                await _tarefaService.RemoveAsync(Id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}

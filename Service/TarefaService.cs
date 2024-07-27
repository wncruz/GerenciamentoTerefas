using Domin.Entities;
using Domin.Interfaces.Repositories;
using Domin.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TarefaService : ITarefaService
    {

        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }


        public async Task<TarefaEntity> AddAsync(TarefaEntity tarefa)
        {
            if (_tarefaRepository.Limite(tarefa.IdProjeto) <= 20)
            {
                return await _tarefaRepository.AddAsync(tarefa);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<TarefaEntity>> GetByProjetoIdAsync(long idPprojeto)
        {
            return await _tarefaRepository.GetByProjetoIdAsync(idPprojeto);
        }

        public async Task RemoveAsync(long id)
        {
            await _tarefaRepository.RemoveAsync(id);
            return;
        }

        public async Task UpdateAsync(TarefaEntity tarefa, string comentario, long IdUusuario)
        {
            await _tarefaRepository.UpdateAsync(tarefa, comentario, IdUusuario);
            return;
        }
    }
}

using Domin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Interfaces.Services
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefaEntity>> GetByProjetoIdAsync(long idPprojeto);
        Task<TarefaEntity> AddAsync(TarefaEntity tarefa);
        Task UpdateAsync(TarefaEntity tarefa, string comentario, long IdUusuario);
        Task RemoveAsync(long id);
    }
}

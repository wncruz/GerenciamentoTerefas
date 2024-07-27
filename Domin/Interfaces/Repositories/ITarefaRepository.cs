using Domin.Entities;

namespace Domin.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<TarefaEntity>> GetByProjetoIdAsync(long idProjeto);
        Task<TarefaEntity> AddAsync(TarefaEntity tarefa);
        Task UpdateAsync(TarefaEntity tarefa, string comentario, long IdUusuario);
        Task RemoveAsync(long id);
        public bool IsPendente(long idProjeto);
        public int Limite(long idProjeto);
    }
}

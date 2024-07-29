using Domin.Entities;

namespace Domin.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<TarefaEntity>> GetByProjetoIdAsync(long idProjeto);
        Task<TarefaEntity> AddAsync(TarefaEntity tarefa);
        Task UpdateAsync(TarefaEntity tarefa, string comentario, long IdUusuario);
        Task RemoveAsync(long id);
        Task<IEnumerable<RelatorioEntity>> GetRelatoriodAsync();
        bool IsPendente(long idProjeto);
        int Limite(long idProjeto);
    }
}

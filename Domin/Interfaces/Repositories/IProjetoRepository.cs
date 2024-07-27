namespace Domin.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        Task<IEnumerable<ProjetoEntity>> GetAllAsync(long IdUsuario);
        Task<ProjetoEntity> GetByIdAsync(long idPprojeto);
        Task<ProjetoEntity> AddAsync(ProjetoEntity projeto);
        Task RemoveAsync(long id);

    }
}

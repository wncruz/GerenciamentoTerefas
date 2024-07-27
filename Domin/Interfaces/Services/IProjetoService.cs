using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Interfaces.Services
{
    public interface IProjetoService
    {
        Task<IEnumerable<ProjetoEntity>> GetAllAsync(long IdUsuario);
        Task<ProjetoEntity> GetByIdAsync(long idPprojeto);
        Task<ProjetoEntity> AddAsync(ProjetoEntity projeto);
        Task<bool> RemoveAsync(long id);
    }
}

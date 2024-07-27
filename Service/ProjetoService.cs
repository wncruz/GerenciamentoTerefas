using Domin;
using Domin.Interfaces.Repositories;
using Domin.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly ITarefaRepository _tarefaRepository;

        public ProjetoService(IProjetoRepository ProjetoRepository, ITarefaRepository tarefaRepository) 
        {
            _projetoRepository = ProjetoRepository;
            _tarefaRepository = tarefaRepository;
        }
        
        public async Task<ProjetoEntity> AddAsync(ProjetoEntity projeto)
        {
            return await _projetoRepository.AddAsync(projeto);
        }

        public async Task<IEnumerable<ProjetoEntity>> GetAllAsync(long IdUsuario)
        {
            return await _projetoRepository.GetAllAsync(IdUsuario);
        }

        public async Task<ProjetoEntity> GetByIdAsync(long idPprojeto)
        {
            return await _projetoRepository.GetByIdAsync(idPprojeto);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            if (_tarefaRepository.IsPendente(id))
            {
                return false;
            }
            await _projetoRepository.RemoveAsync(id);
            return true;
        }
    }
}

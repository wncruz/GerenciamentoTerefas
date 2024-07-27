using Dapper;
using Data.Context;
using Data.Context.Interfaces;
using Domin;
using Domin.Interfaces.Repositories;
using Domin.Util;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using System.Diagnostics.Contracts;

namespace Data.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {

        private readonly IUnitOfWork _uow;

        public ProjetoRepository(IConfiguration configuration, IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ProjetoEntity> AddAsync(ProjetoEntity projeto)
        {
            try
            {
                var query = @"
                    INSERT INTO Projetos (Nome, IdUsuario)
                    VALUES      (@Nome, @IdUsuario);
                    SELECT Id
                          ,Nome
                          ,IdUsuario
                      FROM Projetos
                    WHERE Id = @@IDENTITY;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Nome", projeto.Nome, DbType.String);
                parameters.Add("@IdUsuario", projeto.IdUsuario, DbType.String);

                return await _uow.Connection.QueryFirstOrDefaultAsync<ProjetoEntity>(query.ToString(), parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        public async Task<IEnumerable<ProjetoEntity>> GetAllAsync(long IdUsuario)
        {
            try
            {
                var query = @"
                        SELECT Id
                              ,Nome
                              ,IdUsuario
                         FROM Projetos
                        WHERE IdUsuario = @IdUsuario";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IdUsuario", IdUsuario, DbType.String);

                return await _uow.Connection.QueryAsync<ProjetoEntity>(query.ToString(), parameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProjetoEntity> GetByIdAsync(long idPprojeto)
        {
            try
            {
                var query = @"
                    SELECT Id
                          ,Nome
                          ,IdUsuario
                      FROM Projetos
                    WHERE Id = @Id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", idPprojeto, DbType.String);

                return await _uow.Connection.QueryFirstOrDefaultAsync<ProjetoEntity>(query, parameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveAsync(long id)
        {
            try
            {
                var query = @"
                    DELETE FROM Projetos
                    WHERE Id = @Id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.String);

                await _uow.Connection.QueryFirstOrDefaultAsync(query, parameters);
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

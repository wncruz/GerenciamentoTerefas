using Dapper;
using Data.Context.Interfaces;
using Domin.Entities;
using Domin.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly IUnitOfWork _uow;

        public TarefaRepository(IConfiguration configuration, IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TarefaEntity> AddAsync(TarefaEntity tarefa)
        {
            try
            {
                var query = @"
                    INSERT INTO Tarefas
                           (Titulo
                           ,Descricao
                           ,DataVencimento
                           ,Status
                           ,IdProjeto)
                     VALUES
                           (@Titulo
                           ,@Descricao
                           ,@DataVencimento
                           ,@Status
                           ,@IdProjeto);
                    SELECT Id
                          ,Titulo
                          ,Descricao
                          ,DataVencimento
                          ,Status
                          ,Prioridade
                          ,IdProjeto
                      FROM Tarefas
                    WHERE Id = @@IDENTITY;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Titulo", tarefa.Titulo, DbType.String);
                parameters.Add("@Descricao", tarefa.Descricao, DbType.String);
                parameters.Add("@DataVencimento", tarefa.DataVencimento, DbType.String);
                parameters.Add("@Status", tarefa.Status, DbType.String);
                parameters.Add("@IdProjeto", tarefa.IdProjeto, DbType.String);

                return await _uow.Connection.QueryFirstOrDefaultAsync<TarefaEntity>(query.ToString(), parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TarefaEntity>> GetByProjetoIdAsync(long idProjeto)
        {
            try
            {
                var query = @"
                        SELECT Id
                          ,Titulo
                          ,Descricao
                          ,DataVencimento
                          ,Status
                          ,Prioridade
                          ,IdProjeto
                      FROM Tarefas
                    WHERE IdProjeto = @IdProjeto";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IdProjeto", idProjeto, DbType.String);

                return await _uow.Connection.QueryAsync<TarefaEntity>(query.ToString(), parameters);

            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async Task RemoveAsync(long id)
        {
            try
            {
                var query = @"
                    DELETE FROM Tarefas
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

        public async Task UpdateAsync(TarefaEntity tarefa, string comentario, long IdUusuario)
        {
            try
            {
                var query = @"
                    DECLARE @TituloOld Varchar(50)
                    DECLARE @DescricaoOld Varchar(50)
                    DECLARE @DataVencimentoOld DateTime
                    DECLARE @StatusOld int
                    DECLARE @StatusString varchar(30)
                    DECLARE @StatusStringOld varchar(30)

                    SELECT @TituloOld = Titulo
                         ,@DescricaoOld = Descricao
	                     ,@DataVencimentoOld = DataVencimento
	                     ,@StatusOld = Status
                     FROM Tarefas
                     WHERE Id = @Id;
 
                    IF @StatusOld = 0
	                    SET @StatusStringOld = 'PENDENTE'
                    IF @StatusOld = 1   
	                    SET @StatusStringOld = 'EM ANDAMENTO'
                    IF @StatusOld = 2
	                    SET @StatusStringOld = 'CONCLUIDO'
				 
                    UPDATE Tarefas
	                    SET  Titulo = @Titulo 
		                    ,Descricao = @Descricao
		                    ,DataVencimento = @DataVencimento
		                    ,Status = @Status
                    WHERE Id = @Id;
				 
                    IF @Status = 0
	                    SET @StatusString = 'PENDENTE'
                    IF @Status = 1
	                    SET @StatusString = 'EM ANDAMENTO'
                    IF @Status = 2
	                    SET @StatusString = 'CONCLUIDO'
	
	
                    IF @TituloOld <> @Titulo
                    BEGIN
	                    INSERT INTO HistoricoTarefas
	                    (IdTarefas
	                    ,Altualizacao
	                    ,Comentario
	                    ,DataAtualizacao
	                    ,IdUsuario
	                    ) VALUES (
	                     @Id
	                    ,'Altualizado campo TITULO de ' + @TituloOld + ' para ' + @Titulo
	                    ,@Comentario
	                    ,GETDATE()
	                    ,@IdUsuario)    
                    END

                    IF @DescricaoOld <> @Descricao
                    BEGIN
                        INSERT INTO HistoricoTarefas
	                    (IdTarefas
	                    ,Altualizacao
	                    ,Comentario
	                    ,DataAtualizacao
	                    ,IdUsuario)
	                    VALUES
	                    (@Id
	                    ,'Altualizado campo DESCRICAO de ' + @DescricaoOld + ' para ' + @Descricao
	                    ,@Comentario
	                    ,GETDATE()
	                    ,@IdUsuario)
                    END
	
                    IF @DataVencimento <> @DataVencimentoOld
                    BEGIN                   
                         INSERT INTO HistoricoTarefas
	                     (IdTarefas
	                     ,Altualizacao
	                     ,Comentario
	                     ,DataAtualizacao
	                     ,IdUsuario)
	                     VALUES
	                     (@Id
	                     ,'Altualizado campo DATA VENCIEMNTO de ' + @DataVencimentoOld + ' para ' + @DataVencimento
	                     ,@Comentario
	                     ,GETDATE()
	                     ,@IdUsuario)    
                    END
	
                    IF @Status <> @StatusOld
                    BEGIN
	                    INSERT INTO HistoricoTarefas
	                    (IdTarefas
	                    ,Altualizacao
	                    ,Comentario                                   
	                    ,DataAtualizacao
	                    ,IdUsuario)
	                    VALUES
	                    (@Id
	                    ,'Altualizado campo STATUS de ' + @StatusStringOld + ' para ' + @StatusString
	                    ,@Comentario
	                    ,GETDATE()
	                    ,@IdUsuario)   
                    END
                                ";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", tarefa.Id, DbType.String);
                parameters.Add("@Titulo", tarefa.Titulo, DbType.String);
                parameters.Add("@Descricao", tarefa.Descricao, DbType.String);
                parameters.Add("@DataVencimento", tarefa.DataVencimento, DbType.String);
                parameters.Add("@Status", tarefa.Status, DbType.String);
                parameters.Add("@Comentario", comentario, DbType.String);
                parameters.Add("@IdUsuario", IdUusuario, DbType.String);

                await _uow.Connection.QueryFirstOrDefaultAsync(query, parameters);
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsPendente (long idProjeto)
        {
            var query = @"
                        SELECT Count(*) Total
                         FROM Tarefas
                        WHERE IdProjeto = @IdProjeto
                          AND Status = 0";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IdProjeto", idProjeto, DbType.String);

            _uow.Connection.QueryAsync<TarefaEntity>(query.ToString(), parameters);
            int total = _uow.Connection.QueryFirst(query.ToString(), parameters);
            return (total > 0); 
        }

        public int Limite(long idProjeto)
        {
            var query = @"
                        SELECT Count(*) Total
                         FROM Tarefas
                        WHERE IdProjeto = @IdProjeto";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IdProjeto", idProjeto, DbType.String);

            _uow.Connection.QueryAsync<TarefaEntity>(query.ToString(), parameters);
            int total = _uow.Connection.QueryFirst(query.ToString(), parameters);
            return (total);
        }
    }
}

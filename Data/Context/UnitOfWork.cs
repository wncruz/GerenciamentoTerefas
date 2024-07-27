using Data.Context.Interfaces;
using Domin.Util;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        public IDbConnection Connection { get; }
        public IDbConnection ConnectionMySql { get; }
        public IDbTransaction Transaction { get; private set; }

        public UnitOfWork(IOptions<ConnectionStrings> connectionStrings)
        {
            //_connectionString = connectionStrings.Value.SQLConnection;// ?? throw new InvalidOperationException("A propriedade ConnectionString não foi inicializada.");
            _connectionString = "Data Source=BOOK-FG51SSO1PH\\SQLEXPRESS;Initial Catalog=GERENCIA_TAREFAS;Persist Security Info=True;TrustServerCertificate=True;User ID=sa;Password=Wn172526;Encrypt=True";
            
            Connection = new SqlConnection(_connectionString);
            Connection.Open();
        }


        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            if (Transaction == null)
                throw new Exception("Nenhuma transação inicializada");
            Transaction.Commit();
        }

        public void Dispose()
        {
            if (Transaction != null)
                Transaction.Dispose();
            Connection.Dispose();
        }

        public void Rollback()
        {
            if (Transaction == null)
                throw new Exception("Nenhuma transação inicializada");
            Transaction.Rollback();
        }
    }
}

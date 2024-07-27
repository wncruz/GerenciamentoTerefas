using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Domin.Util
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionString = connectionStrings.Value.SQLConnection ?? throw new InvalidOperationException("A propriedade ConnectionString não foi inicializada.");
        }

        public void Connect()
        {
            Console.WriteLine($"Connecting to database with connection string: {_connectionString}");
            // Aqui você pode adicionar código para conectar ao banco de dados usando a string de conexão.
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                // Execute comandos no banco de dados
            }
        }
    }
}

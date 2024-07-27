using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Data.Context.Interfaces
{
    public interface IUnitOfWork
    {
        public IDbConnection Connection { get; }
        public IDbConnection ConnectionMySql { get; }
        public void BeginTransaction();
        public void Commit();
        public void Dispose();
        public void Rollback();
    }
}

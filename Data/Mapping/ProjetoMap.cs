using Domin;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class ProjetoMap : EntityTypeBuilder<ProjetoEntity>
    {
        public ProjetoMap(IMutableEntityType entityType) : base(entityType)
        {

        }

        //public void Configure(IMutableEntityType<ProjetoEntity> entityType) 
        //{
        //}
    }
}

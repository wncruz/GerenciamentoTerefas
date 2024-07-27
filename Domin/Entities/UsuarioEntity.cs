using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domin.Util.Utilidades;

namespace Domin.Entities
{
    public class UsuarioEntity
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public Funcao Funcao { get; set; }
        //public ICollection<ProjetoEntity> Projetos { get; set; }
    }
}

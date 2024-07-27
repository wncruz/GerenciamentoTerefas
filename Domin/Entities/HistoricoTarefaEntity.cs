using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class HistoricoTarefaEntity
    {
        public long Id { get; set; }
        public long IdTarefas { get; set; }
        public TarefaEntity Tarefas { get; set; }
        public string Altualizacao { get; set; }
        public string Comentario { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public long IdUsuario { get; set; }
        //public UsuarioEntity Usuario { get; set; }
    }
}

using Domin.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domin
{
    public class ProjetoEntity
    {
        //[Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        //public ICollection<TarefaEntity> Tarefas { get; set; }
        public long IdUsuario { get; set; }
        //public UsuarioEntity Usuario { get; set; }
    }
}

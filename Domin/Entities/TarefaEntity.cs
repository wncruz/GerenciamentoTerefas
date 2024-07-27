using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static Domin.Util.Utilidades;

namespace Domin.Entities
{
    public class TarefaEntity
    {
        [Key]
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public Status Status { get; set; }
        public Prioridade Prioridade { get; set; }
        public long IdProjeto { get; set; }
        //public ProjetoEntity Projeto { get; set; }
        //public ICollection<HistoricoTarefaEntity> HistoricoTarefa { get; set; }

    }
}

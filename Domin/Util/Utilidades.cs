using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Util
{
    public class Utilidades
    {
        public enum Status
        {
            Pendente = 0,
            emAndamento = 1,
            Concluida = 2
        }

        public enum Prioridade
        {
            baixa = 0,
            media = 1,
            alta = 2
        }
        public enum Funcao
        {
            Analista = 0,
            Gerente = 1

        }
    }
}

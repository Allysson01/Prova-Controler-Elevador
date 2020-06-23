using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStackService
{
    public class DadosLog
    {
        public DateTime DataInicio { get; set; }
        public long ConsumoMemoriaInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public long ConsumoMemoriaFinal { get; set; }

        public List<object> ListaObjetosEnvio = new List<object>();
        public dynamic ObjetoRetorno { get; set; }
    }
}

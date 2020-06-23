using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace DataStackService
{
    [DataContract]
    public class Dados
    {
        public List<ListaDados> listadados = new List<ListaDados>();

        public class ListaDados
        {
            [DataMember(Name = "sId")]
            public string sId { get; set; }

            [DataMember(Name = "andar")]
            public string andar { get; set; }

            [DataMember(Name = "elevador")]
            public string elevador { get; set; }

            [DataMember(Name = "turno")]
            public string turno { get; set; }
        }
    }
}

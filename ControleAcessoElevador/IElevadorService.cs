using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WinFormsCRUD;

namespace ControleAcessoElevador
{
    
    [ServiceContract]
    public interface IElevadorService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        [return: MessageParameter(Name = "Retorno")]
        [DescricaoWS(sDescricao: "", oType: typeof(List<Dados.ListaDados>))]
        DadosRetorno<List<Dados.ListaDados>> AdicionaConsulta(List<Dados.ListaDados> ListaDados);


        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        [return: MessageParameter(Name = "Retorno")]
        [DescricaoWS(sDescricao: "", oType: typeof(string))]
        DadosRetorno<string> RetornaConsulta();
    }
}

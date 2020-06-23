using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace DataStackService
{
    
    [ServiceContract]
    public interface IDataStackService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        [return: MessageParameter(Name = "Retorno")]
        [DescricaoWS(sDescricao: "", oType: typeof(string))]
        DadosRetorno<string> ReturnSheer(string teste);
    }
}

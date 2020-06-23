using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Web;
using System.Text;

namespace ControleAcessoElevador
{
    [DataContract]
    public class DadosRetorno<T>
    {
        [DataMember]
        public T Dados { get; set; }

        [DataMember]
        public string MensagemErro { get; set; }

        [DataMember]
        public int Status { get; set; }

        public DadosRetorno<T> RetornaRequest(DadosLog oDadosLog, string sErro, IncomingWebRequestContext oRequest)
        {
            this.Dados = string.IsNullOrEmpty(sErro) ? oDadosLog.ObjetoRetorno : null;
            this.MensagemErro = sErro;
            this.Status = string.IsNullOrEmpty(sErro) ? 1 : 0;

            return this;
        }       
    }

    public class DadosRetornoTabelas
    {
        public static System.IO.Stream RetornaRequest(object oRetorno)
        {
            string sSerializado = Newtonsoft.Json.JsonConvert.SerializeObject(oRetorno);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return new System.IO.MemoryStream(Encoding.UTF8.GetBytes(sSerializado));
        }
    }
}

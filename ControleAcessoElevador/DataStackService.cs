using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;


namespace DataStackService
{
    [System.Web.Script.Services.ScriptService]
    public class DataStackService : IDataStackService
    {

        public Message Index()
        {
            var context = WebOperationContext.Current;
            context.OutgoingResponse.ContentType = "application/json";
            return new LandingPageMessage();
        }

        public DadosRetorno<string> ReturnSheer(string teste)
        {
            string sErro = "";
            DadosLog oDadosLog = new DadosLog();
            oDadosLog.DataInicio = DateTime.Now;           
            oDadosLog.ObjetoRetorno = BuildSheetController.ReturnSheer(teste);

            return new DadosRetorno<string>().RetornaRequest(oDadosLog, sErro, WebOperationContext.Current.IncomingRequest);
        }

    }
}

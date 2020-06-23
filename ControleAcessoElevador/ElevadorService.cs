using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using WinFormsCRUD;

namespace ControleAcessoElevador
{
   
    public class ElevadorService : IElevadorService
    {
        string Andar = "";
        string Elevador = "";
        string Turno = "";       

        private const string NomeRetorno = "Retorno";
        private string sDiretorio = System.AppDomain.CurrentDomain.BaseDirectory; 

        private string _BancoDeDados = "";

        public Message Index()
        {
            var context = WebOperationContext.Current;
            context.OutgoingResponse.ContentType = "text/html";
            return new LandingPageMessage();
        }


        public DadosRetorno<List<Dados.ListaDados>> AdicionaConsulta(List<Dados.ListaDados> ListaDados)
        {
            string sErro = "";
            DadosLog oDadosLog = new DadosLog();
            oDadosLog.DataInicio = DateTime.Now;
            oDadosLog.ListaObjetosEnvio.Add(ListaDados);            
            oDadosLog.ObjetoRetorno = ControllerAdicionaDados.AdicionaConsulta(ListaDados);

            return new DadosRetorno<List<Dados.ListaDados>>().RetornaRequest(oDadosLog, sErro, WebOperationContext.Current.IncomingRequest);
        }

        public DadosRetorno<string> RetornaConsulta()
        {
            string sErro = "";
            DadosLog oDadosLog = new DadosLog();
            oDadosLog.DataInicio = DateTime.Now;           
            oDadosLog.ObjetoRetorno = ControllerAdicionaDados.RetornaConsulta();

            return new DadosRetorno<string>().RetornaRequest(oDadosLog, sErro, WebOperationContext.Current.IncomingRequest);
        }

    }
}

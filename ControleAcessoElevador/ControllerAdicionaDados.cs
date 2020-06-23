using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsCRUD;

namespace ControleAcessoElevador
{
    public class ControllerAdicionaDados
    {
        private static SqlConnection oDados = new SqlConnection();


        public static List<Dados.ListaDados> AdicionaConsulta(List<Dados.ListaDados> ListaDados)
        {
            int iCount = 1; 

            List<Dados.ListaDados> lstDs = new List<Dados.ListaDados>();

            foreach (var item in ListaDados)
            {
                Dados.ListaDados ds = new Dados.ListaDados();

                ds.andar = item.andar.ToString();
                ds.elevador = item.elevador.ToString();
                ds.turno = item.turno.ToString();
                ds.sId = iCount++.ToString();
                Cadastro oCad = new Cadastro(ds.andar, ds.elevador, ds.turno);
                lstDs.Add(ds);
            }
            return lstDs;
        }

        public static string RetornaConsulta()
        {
            string Aux = "";
            {
                Cadastro oCad = new Cadastro();

                int A = oCad.RetornaConsultaElevador("A");
                int B = oCad.RetornaConsultaElevador("B");
                int C = oCad.RetornaConsultaElevador("C");
                int D = oCad.RetornaConsultaElevador("D");
                int E = oCad.RetornaConsultaElevador("E");

                Dictionary<string, int> List_Menor = new Dictionary<string, int>();

                List_Menor.Add(nameof(A), A);
                List_Menor.Add(nameof(B), B);
                List_Menor.Add(nameof(C), C);
                List_Menor.Add(nameof(D), D);
                List_Menor.Add(nameof(E), E);

                var menorValor = List_Menor.Min(x => x.Value);
                var Result = List_Menor.FirstOrDefault(x => x.Value == menorValor);

                int Manha = oCad.RetornaConsultaTurno(Result.Key.ToString(), "M");
                int Tarde = oCad.RetornaConsultaTurno(Result.Key.ToString(), "V");
                int Noite = oCad.RetornaConsultaTurno(Result.Key.ToString(), "N");

                Dictionary<string, int> ListTurno = new Dictionary<string, int>();

                ListTurno.Add(nameof(Manha), Manha);
                ListTurno.Add(nameof(Tarde), Tarde);
                ListTurno.Add(nameof(Noite), Noite);

                var menorPeriodo = ListTurno.Min(x => x.Value);
                var ResultPeriodo = ListTurno.FirstOrDefault(x => x.Value == menorPeriodo);


                Aux = "O elevador de menor uso é : " + Result.Key.ToString() + " com apenas " +
                Result.Value.ToString() + " pontos na pesquisa e seu uso é menor no periodo da "+
                ResultPeriodo.Key.ToString()+".  ";
            }

            {
                Cadastro oCad = new Cadastro();

                int A = oCad.RetornaConsultaElevador("A");
                int B = oCad.RetornaConsultaElevador("B");
                int C = oCad.RetornaConsultaElevador("C");
                int D = oCad.RetornaConsultaElevador("D");
                int E = oCad.RetornaConsultaElevador("E");

                Dictionary<string, int> List_Maior = new Dictionary<string, int>();

                List_Maior.Add(nameof(A), A);
                List_Maior.Add(nameof(B), B);
                List_Maior.Add(nameof(C), C);
                List_Maior.Add(nameof(D), D);
                List_Maior.Add(nameof(E), E);

                var maiorValor = List_Maior.Max(x => x.Value);
                var Result = List_Maior.FirstOrDefault(x => x.Value == maiorValor);

                int Manha = oCad.RetornaConsultaTurno(Result.Key.ToString(), "M");
                int Tarde = oCad.RetornaConsultaTurno(Result.Key.ToString(), "V");
                int Noite = oCad.RetornaConsultaTurno(Result.Key.ToString(), "N");

                Dictionary<string, int> ListTurno = new Dictionary<string, int>();

                ListTurno.Add(nameof(Manha), Manha);
                ListTurno.Add(nameof(Tarde), Tarde);
                ListTurno.Add(nameof(Noite), Noite);

                var MaiorPeriodo = ListTurno.Max(x => x.Value);
                var ResultPeriodo2 = ListTurno.FirstOrDefault(x => x.Value == MaiorPeriodo);

                Aux = Aux  + " O elevador de maior uso é : " + Result.Key.ToString() + " com " 
                + Result.Value.ToString() + " pontos na pesquisa e seu uso é maior no periodo da " 
                + ResultPeriodo2.Key.ToString()+".  ";
            }

            {
                Cadastro oCad = new Cadastro();
                int[] Andares = new int[0];
                Dictionary<string, int> List_Menor = new Dictionary<string, int>();

                for (int i = 0; i<15; i++)
                {
                    Array.Resize(ref Andares, Andares.Length + 1);
                    Andares[Andares.Length - 1] = oCad.RetornaConsultaAndar(i.ToString());

                    List_Menor.Add((i+"° Andar"), Andares[Andares.Length - 1]);
                }

                var menorValor = List_Menor.Min(x => x.Value);
                var Result = List_Menor.FirstOrDefault(x => x.Value == menorValor);

                Aux =  Aux + Result.Key.ToString()+" é o menos acessado com "+ Result.Value.ToString()+" acessos. " ;
            }

            {
                Cadastro oCad = new Cadastro();
                int Manha = Convert.ToInt32(oCad.RetornaConsultaPeriodoUtil("M"));
                int Tarde = Convert.ToInt32(oCad.RetornaConsultaPeriodoUtil("V"));
                int Noite = Convert.ToInt32(oCad.RetornaConsultaPeriodoUtil("N"));

                Dictionary<string, int> ListPeriodoutil = new Dictionary<string, int>();

                ListPeriodoutil.Add(nameof(Manha), Manha);
                ListPeriodoutil.Add(nameof(Tarde), Tarde);
                ListPeriodoutil.Add(nameof(Noite), Noite);

                var PeriodoUtil = ListPeriodoutil.Max(x => x.Value);
                var ResultPeriodoUtil = ListPeriodoutil.FirstOrDefault(x => x.Value == PeriodoUtil);

                Aux = Aux + "A maior utilização dos elevadores se dá no periodo da " 
                + ResultPeriodoUtil.Key.ToString() +" com " 
                + ResultPeriodoUtil.Value.ToString() + " Votos.";
            }

            {
                Cadastro oCad = new Cadastro();
                double Manha = oCad.RetornaConsultaPeriodoUtil("M");
                double Tarde = oCad.RetornaConsultaPeriodoUtil("V");
                double Noite = oCad.RetornaConsultaPeriodoUtil("N");

                double iTotal = Manha + Tarde + Noite;

                double resultManha = (Manha * 100) / iTotal;
                double resultTarde = (Tarde * 100) / iTotal;
                double resultNoite = (Noite * 100) / iTotal;

                Aux = Aux + "  A porcentagem de utilização de cada elevador é: Manhã ("
                + resultManha.ToString("F") + "), Tarde (" 
                + resultTarde.ToString("F") + "), Noite (" 
                + resultNoite.ToString("F") + ").  "; 
            }
            return Aux;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsCRUD
{
    public class Cadastro
    {
        Conexao oConex = new Conexao();
        SqlCommand oComando = new SqlCommand();
        
        public string sMsgRetorno = "";
        string sQuery = "";

        int Id = 0;
        public Cadastro() { }

            public Cadastro(string sAndar, string sElevador, string sTurno)
        {
            try
            {
                sQuery = string.Format(@"select ISNULL(MAX(id)+1, 1) from DadosElevador");

                DataTableReader iId = oConex.RetornaConsultaSQL(sQuery);

                if (iId.HasRows)
                {
                    while (iId.Read())
                    {
                        Id = Convert.ToInt32(iId[0].ToString());
                    }
                    
                }               


                string sInsert = string.Format(@"insert into DadosElevador (Id,Andar, Elevador, Turno) values ({0}, {1}, '{2}', '{3}')", Id, sAndar, sElevador, sTurno);


                oComando.CommandText = sInsert;


                try
                {
                    oComando.Connection = oConex.Conectar();

                    oComando.ExecuteNonQuery();

                    this.sMsgRetorno = "Cadastrado com Sucesso!";
                }
                catch (SqlException ex)
                {
                    this.sMsgRetorno = "Erro ao tentar se conectar com o banco de dados" + ex.ToString();
                }
                finally
                {
                    oConex.Desconectar();
                }                  
            }catch(SqlException) { }
        }

        public int RetornaConsultaElevador(string sPesquisa)
        {
            int Quant = 0;

            sQuery = string.Format(@"select COUNT(Elevador) from DadosElevador where Elevador = '{0}'", sPesquisa);

                var Reader = oConex.RetornaConsultaSQL(sQuery);

                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        
                        Quant = Convert.ToInt32(Reader[0].ToString());
                     
                    }

                }
                return Quant;            
        }

        public double RetornaConsultaPeriodoUtil(string sPesquisa)
        {
            double Quant = 0;

            sQuery = string.Format(@"select Count(Turno) from DadosElevador where Turno = '{0}'", sPesquisa);

            var Reader = oConex.RetornaConsultaSQL(sQuery);

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {

                    Quant = Convert.ToInt32(Reader[0].ToString());

                }

            }
            return Quant;
        }

        public int RetornaConsultaTurno(string sPesquisa, string Turno)
        {
            int Quant = 0;

            sQuery = string.Format(@"select COUNT(Elevador) from DadosElevador where Elevador = '{0}'", sPesquisa, Turno);

            var Reader = oConex.RetornaConsultaSQL(sQuery);

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {

                    Quant = Convert.ToInt32(Reader[0].ToString());

                }

            }
            return Quant;
        }

        public int RetornaConsultaAndar(string sPesquisa)
        {
            int Quant = 0;

            sQuery = string.Format(@"select COUNT(Andar) from DadosElevador where Andar = '{0}'", sPesquisa);

            var Reader = oConex.RetornaConsultaSQL(sQuery);

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {

                    Quant = Convert.ToInt32(Reader[0].ToString());

                }

            }
            return Quant;
        }
        public List<Dados.ListaDados> RetornaConsulta(string sPesquisa)
                  {
                   
                      List<Dados.ListaDados> lstRetorno = new List<Dados.ListaDados>();

                     
                       sQuery = string.Format(@"SELECT * FROM DadosElevador");

                     

                      var oReader = oConex.RetornaConsultaSQL(sQuery);

                      if (oReader.HasRows) {
                          while (oReader.Read()) {                   

                              Dados.ListaDados oDados = new Dados.ListaDados();
                              oDados.sId       = oReader[0].ToString();
                              oDados.andar    = oReader[1].ToString();
                              oDados.elevador = oReader[2].ToString();
                              oDados.turno    = oReader[3].ToString();
                              lstRetorno.Add(oDados);
                          }
                          

                      }

                      oConex.Desconectar();
                      return lstRetorno;
                  }
            
    }
}

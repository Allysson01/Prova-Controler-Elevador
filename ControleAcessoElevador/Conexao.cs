using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsCRUD
{
    
    public class Conexao
    {
        SqlConnection conectar;

        public Conexao()
        {
            conectar = new SqlConnection();
            conectar.ConnectionString = @"Data Source = BRUNA\SQLEXPRESS;Initial Catalog = ControleAcessoElevador; Integrated Security = True"; 
        }

        public SqlConnection Conectar() 
        {
            if (conectar.State == System.Data.ConnectionState.Closed) 
            {
                conectar.Open();
            }
            return conectar;
        }

        public void Desconectar()
        {
            if (conectar.State == System.Data.ConnectionState.Open) {
                conectar.Close();
            }
        }

        public DataTableReader RetornaConsultaSQL(string sQuery) {

            SqlDataReader oReader = null;
            SqlCommand command;

            try {

                command = new SqlCommand(sQuery, Conectar());
                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.SelectCommand = command;              
                DataTable oDataTable = new DataTable();
                adpt.Fill(oDataTable);            
                return oDataTable.CreateDataReader();

            } catch (Exception) {

                return null;

            } finally {

                if (oReader != null) {
                    if (!oReader.IsClosed)
                        oReader.Close();
                    oReader.Dispose();
                    Desconectar();
                }
            }
        }
    }
}

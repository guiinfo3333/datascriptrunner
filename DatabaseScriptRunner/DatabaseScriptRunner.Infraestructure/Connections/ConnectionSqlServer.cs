using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseScriptRunner.Infraestructure.Connections
{
    public class ConnectionSqlServer
    {
        string cadena = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\NathanSilvaCosta\\Documents\\BancoNew.mdf;Integrated Security=True;Connect Timeout=30";
        public SqlConnection conectarbd = new SqlConnection();

        public ConnectionSqlServer()
        {
            conectarbd.ConnectionString = cadena;         
        }

        public void abrir(){
            try
            {
                conectarbd.Open();
                Console.WriteLine("Conexao aberta");
            }
            catch(Exception err)
            {
                Console.WriteLine("Error" + err.Message);
            }
        }
        public void cerrar()
        {
            conectarbd.Close();
        }
    }
}

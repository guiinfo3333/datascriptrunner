using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseScriptRunner.Infraestructure.RunnerScript
{
       public class Connection
    {

        protected string conecta { get; set; }
       
        // string conecta = "Database=crud;SERVER=localhost;UID=root;PWD=3103";
        MySqlConnection conexao = null;
        public Connection(string conexao)
        {
            conecta = conexao;

        }

        public void AbrirConexao()
        {
            try
            {
                    conexao = new MySqlConnection(conecta);
                    conexao.Open();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conexao.Close();
            }
        }
        public void FechaConexao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Close();

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


    }
}

using DatabaseScriptRunner.Domain.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseScriptRunner.Infraestructure.RunnerScript
{
    public class RunnerScript1
    {
        public string conecta;
        public string nomebanco;
        MySqlCommand command = null;

        public RunnerScript1(string conexao, string nomeb)
        {
            conecta = conexao;
            nomebanco = nomeb;
        }
        public Resultado ExecuteAll(Script script)
        {


            Resultado r1 = new Resultado();
            r1.textresult = "código de insert executado com sucesso no banco" + nomebanco;



            // CODIGO INSERT //
            if ((script.text).Contains("insert") || (script.text).Contains("INSERT"))
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(conecta);
                    conn.Open();
                    string query = script.text;
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();

                }
                catch
                {
                    r1.textresult = "não foi possível executar o código INSERT no banco " + nomebanco;

                }

            }

            else if ((script.text).Contains("select") || (script.text).Contains("SELECT"))
            {
  
                try
                {
                    MySqlConnection conn = new MySqlConnection(conecta);
                    conn.Open();
                    string query = script.text;
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        //    cmd.ExecuteNonQuery();
                        using (MySqlDataReader rd = cmd.ExecuteReader())
                        {
                           
                            r1.getter = new List<string>();
                            string pegatudo= null;
                            int winner = rd.FieldCount;
                            int number = rd.RecordsAffected;
                            r1.afectedrows = number;
                            while (rd.Read())
                            {
                                
                                for (int t = 0; t < winner; t++)   //6  t=7
                                {
                                    if (t==(winner-1))
                                    {
                                        pegatudo += rd.GetString(t);
                                    }
                                    else
                                    {
                                        pegatudo += rd.GetString(t) + " ,";
                                    }
                                   

                                }
                                r1.getter.Add(pegatudo);
                                pegatudo = null;
                            }
                            //pegando a quantidade de campos
                          
                           
                            /////////////////////////////
                           
                        }
                    }


                    r1.textresult = "comando de select executado com sucesso no banco " + nomebanco;
                 
                    conn.Close();

                }
                catch
                {
                    r1.textresult = "não foi possível executar o código SELECT no banco " + nomebanco;

                }


            }
            else if ((script.text).Contains("update") || (script.text).Contains("UPDATE"))
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(conecta);
                    conn.Open();
                    string query = script.text;
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    r1.textresult = "código de update executado com sucesso no banco" + nomebanco;
                }
                catch
                {
                    r1.textresult = "não foi possível executar o código UPDATE no banco " + nomebanco;

                }
            }
            else if ((script.text).Contains("delete") || (script.text).Contains("DELETE"))
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(conecta);
                    conn.Open();
                    string query = script.text;
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    r1.textresult = "código de delete executado com sucesso no banco " + nomebanco;
                }
                catch
                {
                    r1.textresult = "não foi possível executar o código DELETE no banco " + nomebanco;

                }

            }
            else
            {
                try
                {
                    r1.getter = new List<string>();
                    MySqlConnection conn = new MySqlConnection(conecta);
                    conn.Open();
                    string query = script.text;
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                   
                    //    cmd.ExecuteNonQuery();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    int winner = rd.FieldCount;


                    if (rd.Read())
                     {
                        for (int i = 0; i <winner; i++)
                        {

                        r1.getter.Add(rd[i].ToString());
                        }




                    }
                       
                        
                    
                      

                    r1.textresult = "comando executado com sucesso no banco " + nomebanco;

                    conn.Close();


                }
                catch(Exception error)
                {
               
                    r1.textresult = "não foi possível executar este comando no banco" + nomebanco;

                }

            }

            return r1;
                            }
    }
}

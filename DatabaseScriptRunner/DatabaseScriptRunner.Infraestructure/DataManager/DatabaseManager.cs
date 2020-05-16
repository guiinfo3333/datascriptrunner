using DatabaseScriptRunner.Domain.Entities;
using DatabaseScriptRunner.Infraestructure.Connections;
using DatabaseScriptRunner.Infraestructure.Data;
using DatabaseScriptRunner.Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DatabaseScriptRunner.Infraestructure.DataManager
{
    public class DatabaseManager:IDataRepository<Database>
    {
        readonly DatabaseContext _databaseContext;

        public DatabaseManager(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public IEnumerable<Database> GetAll()
        {
            return _databaseContext.Databases.ToList();
            //return _databaseContext.Databases.Include("UserDatabases").ToList();
        }

        public Database Get(long id)
        {
            return _databaseContext.Databases
                  .FirstOrDefault(e => e.IdDatabase == id);
        }

        public void Add(Database entity)
        {
            _databaseContext.Databases.Add(entity);
            _databaseContext.SaveChanges();
        }

        public void Update(Database database, Database entity)
        {
            database.Name = entity.Name;
            database.ConnectionString = entity.ConnectionString;
            
            _databaseContext.SaveChanges();
        }

        public void Delete(Database database)
        {
            _databaseContext.Databases.Remove(database);
            _databaseContext.SaveChanges();
        }

        public bool Login(Database entity)
        {
            throw new NotImplementedException();
        }

        public Database Forname(string id)
        {
            throw new NotImplementedException();
        }
        public Resultado ultimoId()
        {
            Resultado rr = new Resultado();
            ConnectionSqlServer cc = new ConnectionSqlServer();
            cc.abrir();
            string cadena = "select max(idDatabase) from Databases ";
            try
            {
                SqlCommand command = new SqlCommand(cadena, cc.conectarbd);
                SqlDataReader lector = command.ExecuteReader();
                while (lector.Read())
                {
                    rr.textresult = lector[0].ToString();
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("errado " + err.Message);
            }
            return rr;
        }
     

        public List<Database> PegaBanco(long id)
        {

            List<Database> tabeladebancos = new List<Database>();
            ConnectionSqlServer cc = new ConnectionSqlServer();
            cc.abrir();
            string cadena = "select b.Name,b.ConnectionString,b.IdDatabase from UserDatabase a inner join Databases b on a.IdDatabase = b.IdDatabase inner join Users c on a.IdUser = c.IdUser where c.IdUser =" + id;
            try
            {
                SqlCommand command = new SqlCommand(cadena, cc.conectarbd);
                SqlDataReader lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Database rr = new Database();
                    rr.Name = lector[0].ToString();
                    rr.ConnectionString = lector[1].ToString();
                    rr.IdDatabase = (int)lector[2];
                    tabeladebancos.Add(rr);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("errado " + err.Message);
            }
            return tabeladebancos;
        }
    }
}

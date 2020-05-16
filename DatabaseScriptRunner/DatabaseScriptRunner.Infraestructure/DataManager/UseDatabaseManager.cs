using DatabaseScriptRunner.Domain.Entities;
using DatabaseScriptRunner.Infraestructure.Data;
using DatabaseScriptRunner.Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseScriptRunner.Infraestructure.DataManager
{
    public class UseDatabaseManager : IDataRepository<UserDatabase>
    {
        readonly DatabaseContext _databaseContext;

        public UseDatabaseManager (DatabaseContext context)
        {
            _databaseContext = context;
        }

        public void Add(UserDatabase entity)
        {
            _databaseContext.UserDatabases.Add(entity);
            _databaseContext.SaveChanges();
        }

        public void Delete(UserDatabase entity)
        {
            throw new NotImplementedException();
        }

        public UserDatabase Forname(string login)
        {
            throw new NotImplementedException();
        }

        public UserDatabase Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDatabase> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Login(UserDatabase entity)
        {
            throw new NotImplementedException();
        }

        public List<Database> PegaBanco(long id)
        {
            throw new NotImplementedException();
        }

        public Resultado ultimoId()
        {
            throw new NotImplementedException();
        }

        public void Update(UserDatabase dbEntity, UserDatabase entity)
        {
            throw new NotImplementedException();
        }
    }
}

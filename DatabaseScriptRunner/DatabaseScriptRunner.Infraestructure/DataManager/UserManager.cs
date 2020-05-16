using DatabaseScriptRunner.Domain.Entities;
using DatabaseScriptRunner.Infraestructure.Data;
using DatabaseScriptRunner.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseScriptRunner.Infraestructure.DataManager
{
    public class UserManager:IDataRepository<User>
    {
        readonly DatabaseContext _databaseContext;

        public UserManager(DatabaseContext context)
        {
            _databaseContext = context;
        }


        public IEnumerable<User> GetAll()
        {
            //return _databaseContext.Users.ToList();
            return _databaseContext.Users.Include("UserDatabases").ToList();
            
        }

        public User Get(long id)
        {
            return _databaseContext.Users.Include("UserDatabases")
                  .FirstOrDefault(e => e.IdUser == id);
        }

        public void Add(User entity)
        {
            _databaseContext.Users.Add(entity);
            _databaseContext.SaveChanges();
        }

       public bool Login(User entity)
        {
          bool situacao = false;
          
            var Usuario = _databaseContext.Users.FirstOrDefault(x => x.Login == entity.Login && x.Password == entity.Password);
      if (Usuario != null)
            {
      
                 situacao = true;
            }
            else
            {
            }
            return situacao;
            
       }

        public void Update(User user, User entity)
        {
            user.Name = entity.Name;
            user.Login = entity.Login;
            user.Password = entity.Password;

            _databaseContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _databaseContext.Users.Remove(user);
            _databaseContext.SaveChanges();
        }

        public User Forname(string login)
        {
            return _databaseContext.Users
                .FirstOrDefault(e => e.Login ==login);
        }

        public Resultado ultimoId()
        {
            throw new NotImplementedException();
        }

        public List<Database> PegaBanco(long id)
        {
            throw new NotImplementedException();
        }
    }
}

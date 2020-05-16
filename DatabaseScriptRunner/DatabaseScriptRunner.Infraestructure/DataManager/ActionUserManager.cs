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
    public class ActionUserManager : IDataRepository<ActionUser>
    {
        readonly DatabaseContext _actionContext;
        public ActionUserManager(DatabaseContext context)
        {
            _actionContext = context;

        }
        public void Add(ActionUser entity)
        {
            _actionContext.ActionUsers.Add(entity);
            _actionContext.SaveChanges();
        }

        public void Delete(ActionUser entity)
        {
            _actionContext.ActionUsers.Remove(entity);
            _actionContext.SaveChanges();
        }

        public ActionUser Forname(string login)
        {
            throw new NotImplementedException();
        }

        public ActionUser Get(long id)
        {
            return _actionContext.ActionUsers.FirstOrDefault(e => e.IdUser == id);
        }

        public ActionUser Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ActionUser> GetAll()
        {
            return _actionContext.ActionUsers.ToList();
        }

        public bool Login(ActionUser entity)
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

        public void Update(ActionUser dbEntity, ActionUser entity)
        {
            throw new NotImplementedException();
        }
    }
}

using DatabaseScriptRunner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseScriptRunner.Infraestructure.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);

        TEntity Forname(string login);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);

        bool Login(TEntity entity);

        Resultado ultimoId();

        List<Database> PegaBanco(long id);
    }
}

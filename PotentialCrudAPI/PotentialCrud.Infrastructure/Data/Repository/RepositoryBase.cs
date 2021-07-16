using PotentialCrudDomain.Core.Interface.Repository;
using PotentialCrudDomain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PotentialCrud.Infrastructure.Data.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public int Add(TEntity obj)
        {
            sqlContext.Set<TEntity>().Add(obj);
            sqlContext.SaveChanges();

            return (obj as Desenvolvedor).Id;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return sqlContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return sqlContext.Set<TEntity>().Find(id);
        }        

        public void Remove(TEntity obj)
        {
            sqlContext.Set<TEntity>().Remove(obj);
            sqlContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            sqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            sqlContext.SaveChanges();
        }
    }
}

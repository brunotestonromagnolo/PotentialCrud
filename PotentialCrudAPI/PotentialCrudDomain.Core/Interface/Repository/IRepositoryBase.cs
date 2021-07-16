using System.Collections.Generic;

namespace PotentialCrudDomain.Core.Interface.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        int Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);        
    }
}

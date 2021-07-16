using System.Collections.Generic;

namespace PotentialCrudDomain.Core.Interface.Service
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetlAll();

        TEntity GetById(int id);

        IEnumerable<TEntity> GetListById(int id);

        int Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);       

    }
}

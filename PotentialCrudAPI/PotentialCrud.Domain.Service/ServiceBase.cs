using PotentialCrudDomain.Core.Interface.Repository;
using PotentialCrudDomain.Core.Interface.Service;
using System.Collections.Generic;

namespace PotentialCrud.Domain.Service
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public int Add(TEntity obj)
        {
            return repository.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<TEntity> GetListById(int id)
        {
            var entity = repository.GetById(id);
            if (entity == null) return new List<TEntity>();

            return new List<TEntity>() { entity };
        }

        public IEnumerable<TEntity> GetlAll()
        {
            return repository.GetAll();
        }

        public void Remove(TEntity obj)
        {
            repository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }
    }
}

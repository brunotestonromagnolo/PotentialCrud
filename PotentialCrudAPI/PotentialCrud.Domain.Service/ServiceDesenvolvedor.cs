using PotentialCrudDomain.Core.Interface.Repository;
using PotentialCrudDomain.Core.Interface.Service;
using PotentialCrudDomain.Entity;

namespace PotentialCrud.Domain.Service
{
    public class ServiceDesenvolvedor : ServiceBase<Desenvolvedor>, IServiceDesenvolvedor
    {
        private readonly IRepositoryDesenvolvedor repositoryDesenvolvedor;

        public ServiceDesenvolvedor(IRepositoryDesenvolvedor repositoryDesenvolvedor) : base(repositoryDesenvolvedor)
        {
            this.repositoryDesenvolvedor = repositoryDesenvolvedor;
        }
    }
}

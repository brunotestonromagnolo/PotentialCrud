using PotentialCrudDomain.Core.Interface.Repository;
using PotentialCrudDomain.Entity;

namespace PotentialCrud.Infrastructure.Data.Repository
{
    public class RepositoryDesenvolvedor : RepositoryBase<Desenvolvedor>, IRepositoryDesenvolvedor
    {
        private readonly SqlContext sqlContext;

        public RepositoryDesenvolvedor(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}

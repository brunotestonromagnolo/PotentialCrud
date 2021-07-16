using Microsoft.EntityFrameworkCore;
using PotentialCrudDomain.Entity;

namespace PotentialCrud.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
        
        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }
        
    }
}

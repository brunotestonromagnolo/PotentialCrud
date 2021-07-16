using System.ComponentModel.DataAnnotations;

namespace PotentialCrudDomain.Entity
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }
    }
}

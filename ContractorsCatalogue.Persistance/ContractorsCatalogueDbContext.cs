using ContractorsCatalogue.Domain.Entities;
using System.Data.Entity;

namespace ContractorsCatalogue.Persistance
{
    public class ContractorsCatalogueDbContext : DbContext
    {
        public DbSet<Contractor> Contractors { get; set; }
    }
}

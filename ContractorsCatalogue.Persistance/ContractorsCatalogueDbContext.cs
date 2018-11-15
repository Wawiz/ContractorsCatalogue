using ContractorsCatalogue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractorsCatalogue.Persistance
{
    public class ContractorsCatalogueDbContext : DbContext
    {
        public DbSet<Contractor> Contractors { get; set; }
    }
}

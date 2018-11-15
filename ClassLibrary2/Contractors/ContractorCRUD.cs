using ContractorsCatalogue.App.Interfaces;
using ContractorsCatalogue.Domain.Entities;
using ContractorsCatalogue.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace ContractorsCatalogue.App.Contractors
{
    public class ContractorCRUD  : IEntityCRUD<Contractor>
    {
        private ContractorsCatalogueDbContext dbContext;

        public ContractorCRUD()
        {
            dbContext = new ContractorsCatalogueDbContext();
        }

        public bool Create(Contractor newContractor)
        {
            var validator = new ContractorValidator();
            if(validator.Validate(newContractor))
            {
                dbContext.Contractors.Add(newContractor);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Contractor Get(int id)
        {
            return dbContext.Contractors.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Contractor> GetAll()
        {
            return dbContext.Contractors.ToList();
        }

        public bool Update(Contractor contractor)
        {
            var validator = new ContractorValidator();
            if (!validator.Validate(contractor))
                return false;

            var createdContractor = dbContext.Contractors.FirstOrDefault(c => c.Id == contractor.Id);
            if(createdContractor != null)
            {
                createdContractor.FirstName = contractor.FirstName;
                createdContractor.LastName = contractor.LastName;
                createdContractor.NIP = contractor.NIP;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Contractor contractor)
        {
            var contractorToRemove = dbContext.Contractors.FirstOrDefault(c => c.Id == contractor.Id);
            if(contractorToRemove != null)
            {
                dbContext.Contractors.Remove(contractorToRemove);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

using ContractorsCatalogue.App.Interfaces;
using ContractorsCatalogue.Domain.Entities;

namespace ContractorsCatalogue.App.Contractors
{
    class ContractorValidator : IValidator<Contractor>
    {
        public bool Validate(Contractor obj)
        {
            return obj.FirstName.Length > 0 && obj.LastName.Length > 0 && obj.NIP.Length > 0;
        }
    }
}

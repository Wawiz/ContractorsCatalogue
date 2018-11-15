using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractorsCatalogue.App.Interfaces
{
    interface IValidator<T>
    {
        bool Validate(T obj);
    }
}

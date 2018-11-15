using System.Collections.Generic;

namespace ContractorsCatalogue.App.Interfaces
{
    interface IEntityCRUD<T>
    {
        bool Create(T obj);
        T Get(int id);
        IEnumerable<T> GetAll();
        bool Update(T obj);
        bool Delete(T obj);
    }
}

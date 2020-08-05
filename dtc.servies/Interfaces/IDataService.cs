using dtc.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dtc.services.Interfaces
{
    public interface IDataService<T>
    {
        Task<List<T>> Get(ItemCollectionTypes type);
        Task<T> GetById(string Id);

        Task<T> Upsert(T item);

    }
}

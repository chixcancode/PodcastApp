using dtc.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dtc.services.Interfaces
{
    public interface IHostService
    {
        Task<List<Host>> Get();
        Task<Host> GetById(string Id);

        Task<Host> Upsert(Host episode);
    }
}

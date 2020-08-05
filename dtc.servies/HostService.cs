using dtc.models;
using dtc.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dtc.services
{
    public class HostService : IHostService
    {
        public Task<List<Host>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Host> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<Host> Upsert(Host episode)
        {
            throw new NotImplementedException();
        }
    }
}

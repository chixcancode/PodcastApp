using dtc.models;
using dtc.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dtc.services
{
    public class GuestService : IGuestService
    {
        public Task<List<Guest>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<Guest>> GetByEpisode(string episodeId)
        {
            throw new NotImplementedException();
        }

        public Task<Guest> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Episode> Upsert(Episode episode)
        {
            throw new NotImplementedException();
        }
    }
}

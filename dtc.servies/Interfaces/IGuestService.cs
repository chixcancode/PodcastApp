using dtc.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dtc.services.Interfaces
{
    public interface IGuestService
    {
        Task<List<Guest>> Get();
        Task<List<Guest>> GetByEpisode(string episodeId);

        Task<Guest> GetById(string id);
        Task<Episode> Upsert(Episode episode);
    }
}

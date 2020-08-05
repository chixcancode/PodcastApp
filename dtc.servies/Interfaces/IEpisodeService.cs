using dtc.models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace dtc.services.Interfaces
{
    public interface IEpisodeService
    {

        Task<List<Episode>> Get();
        Task<Episode> GetById(string Id);

        Task<Episode> Upsert(Episode episode);

        Task Translate(TranscriptionDefinition transcriptionDefinition);

           

    }
}

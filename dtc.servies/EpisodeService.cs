using dtc.models;
using dtc.services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dtc.services
{
    public class EpisodeService : IEpisodeService
    {
        private IDataService<Episode> _dataService;
        public EpisodeService(IDataService<Episode> dataService, IConfiguration configuration)
        {
            _dataService = dataService;

        }
        public async Task<List<Episode>> Get()
        {
            return await _dataService.Get(ItemCollectionTypes.Episode);
        }

        public async Task<Episode> GetById(string Id)
        {
            return await _dataService.GetById(Id);
        }

        public Task Translate(TranscriptionDefinition transcriptionDefinition)
        {
            throw new NotImplementedException();
        }

        public async Task<Episode> Upsert(Episode episode)
        {
            return await _dataService.Upsert(episode);
        }
    }
}

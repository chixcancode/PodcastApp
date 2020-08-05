using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using dtc.services.Interfaces;
using dtc.models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace dtc.functionapp.episodes
{  public class EpisodeFunctions
    {

        private readonly IDataService<Episode> _dataService;
        private readonly IEpisodeService _episodeService;
        private readonly IConfiguration _config;

        public EpisodeFunctions(IDataService<Episode> dataService, IEpisodeService episodeService, IConfiguration config)
        {
            this._config = config;
            this._dataService = dataService;
            this._episodeService = episodeService;

        }

        [FunctionName("EpisodesGet")]
        public async Task<IActionResult> GetEpisodes(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "episodes")] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("Get Episodes function called");
                List<Episode> episodes = await _episodeService.Get();

                return (ActionResult)new OkObjectResult(episodes);
            }
            catch(Exception ex)
            {
                var error = $"GetEpisodes failed: {ex.Message}";
                log.LogError(error);
                return new BadRequestObjectResult(error);
            }
            
        }


        [FunctionName("EpisodesGetById")]
        public async Task<IActionResult> GetEpisodesById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "episodes/{id}")] HttpRequest req,
            string id,
            ILogger log)
        {
            try
            {
                log.LogInformation("Get Episodes function called");
                Episode episode = await _episodeService.GetById(id);

                return (ActionResult)new OkObjectResult(episode);
            }
            catch (Exception ex)
            {
                var error = $"GetEpisodes failed: {ex.Message}";
                log.LogError(error);
                return new BadRequestObjectResult(error);
            }

        }

        [FunctionName("UpsertEpisode")]
        public async Task<IActionResult> UpsertEpisode(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "episodes")] HttpRequest req,
           ILogger log)
        {
            try
            {
                log.LogInformation("Upsert episode function called");
                return null;
            }
            catch (Exception ex)
            {
                var error = $"GetEpisodes failed: {ex.Message}";
                log.LogError(error);
                return new BadRequestObjectResult(error);
            }

        }
    }
}

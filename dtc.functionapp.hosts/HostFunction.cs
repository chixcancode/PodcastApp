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

namespace dtc.functionapp.hosts
{
    public class HostFunctions
    {

        private readonly IDataService<Host> _dataService;
        private readonly IHostService _hostService;
        private readonly IConfiguration _config;

        public HostFunctions(IDataService<Host> dataService, IHostService hostService, IConfiguration config)
        {
            this._config = config;
            this._dataService = dataService;
            this._hostService = hostService;

        }

        [FunctionName("HostsGet")]
        public async Task<IActionResult> Gethosts(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "hosts")] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("Get hosts function called");
                List<Host> hosts = await _hostService.Get();

                return (ActionResult)new OkObjectResult(hosts);
            }
            catch (Exception ex)
            {
                var error = $"Get hosts failed: {ex.Message}";
                log.LogError(error);
                return new BadRequestObjectResult(error);
            }

        }


        [FunctionName("HostsGetById")]
        public async Task<IActionResult> GetHostsById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "hosts/{id}")] HttpRequest req,
            string id,
            ILogger log)
        {
            try
            {
                log.LogInformation("Get hosts function called");
                Host host = await _hostService.GetById(id);

                return (ActionResult)new OkObjectResult(host);
            }
            catch (Exception ex)
            {
                var error = $"Gethosts failed: {ex.Message}";
                log.LogError(error);
                return new BadRequestObjectResult(error);
            }

        }

        [FunctionName("UpsertHost")]
        public async Task<IActionResult> UpsertHost(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "hosts")] HttpRequest req,
           ILogger log)
        {
            try
            {
                log.LogInformation("Upsert host function called");
                return null;
            }
            catch (Exception ex)
            {
                var error = $"Update hosts failed: {ex.Message}";
                log.LogError(error);
                return new BadRequestObjectResult(error);
            }

        }
    }
}

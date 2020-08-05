using dtc.models;
using dtc.services;
using dtc.services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

[assembly: FunctionsStartup(typeof(dtc.functionapp.episodes.Startup))]

namespace dtc.functionapp.episodes
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Add configuration file support for injection
            //  Determine whether running locally or in Azure
            var localRoot = Environment.GetEnvironmentVariable("AzureWebJobsScriptRoot");
            var azureRoot = $"{Environment.GetEnvironmentVariable("HOME")}/site/wwwroot";
            var actualRoot = localRoot ?? azureRoot;

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(actualRoot)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT")}.json", optional: true)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .AddEnvironmentVariables();

            IConfiguration configuration = configBuilder.Build();
            builder.Services.AddSingleton(configuration);
            //Inject Dependencies
            builder.Services.AddSingleton<IDataService<Episode>, dtc.services.CosmosDataService<Episode>>();
            builder.Services.AddSingleton<IDataService<Host>, CosmosDataService<Host>>();
            builder.Services.AddSingleton<IDataService<Guest>, CosmosDataService<Guest>>();
            builder.Services.AddSingleton<IEpisodeService,EpisodeService>();
            builder.Services.AddSingleton<IGuestService, GuestService>();
            builder.Services.AddSingleton<IHostService, HostService>();







        }
    }
}


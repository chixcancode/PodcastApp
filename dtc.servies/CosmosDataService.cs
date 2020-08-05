using dtc.models;
using dtc.services.Interfaces;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dtc.services
{
    public class CosmosDataService<T> : IDataService<T> where T : Entity
    {

        // Cosmos DocDB API database
        private static string _docDbEndpointUri;
        private static string _docDbPrimaryKey;
        private static string _docDbDatabaseName;
        private static string _docDbCollectionUri;

        // Doc DB Collections
        private static string _docDbPodcastCollection;
        private static DocumentClient _documentClient;


        public CosmosDataService(IConfiguration config)
        {
            _docDbEndpointUri = config["CosmosDBEndpointUri"];
            _docDbPrimaryKey = config["CosmosDBPrimaryKey"];

            _docDbDatabaseName = config["CosmosDBDatabaseName"];
            _docDbPodcastCollection = config["CosmosDBCollectionName"];
        }

        public async Task<List<T>> Get(ItemCollectionTypes type)
        {
            FeedOptions queryOptions = new FeedOptions { EnableCrossPartitionQuery = true };
            var query = (await GetDocDBClient()).CreateDocumentQuery<T>(
                            UriFactory.CreateDocumentCollectionUri(_docDbDatabaseName, _docDbPodcastCollection), queryOptions)
                            .Where(e => e.CollectionType == type)
                            .OrderByDescending(e => e.UpsertDate);
                           
            return query.ToList();
        }

        public Task<T> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Upsert(T item)
        {
            throw new NotImplementedException();
        }

        private static async Task<DocumentClient> GetDocDBClient()
        {
            if (_documentClient == null)
            {
                var docDbEndpointUrl = _docDbEndpointUri;
                var docDbApiKey = _docDbPrimaryKey;


                _documentClient = new DocumentClient(new Uri(docDbEndpointUrl), docDbApiKey);
            }
            return _documentClient;
        }

    }
}

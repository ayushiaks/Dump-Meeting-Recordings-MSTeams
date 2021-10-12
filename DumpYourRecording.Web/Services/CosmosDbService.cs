using System;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DumpYourRecording.Web.Services.Interfaces;
using DumpYourRecording.Web.Models;

namespace DumpYourRecording.Web.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container container;

        public CosmosDbService(
            CosmosClient cosmosClient,
            string databaseName,
            string containerName)
        {
            this.container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(RecordingEntity entity)
        {
            await this.container.CreateItemAsync<RecordingEntity>(entity, new PartitionKey(entity.Id));
        }

        public async Task<IEnumerable<RecordingEntity>> GetItemsAsync(string queryString)
        {
            var query = this.container.GetItemQueryIterator<RecordingEntity>(new QueryDefinition(queryString));
            List<RecordingEntity> results = new List<RecordingEntity>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
    }
}

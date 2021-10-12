using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DumpYourRecording.Web.Models;

namespace DumpYourRecording.Web.Services.Interfaces
{
    public interface ICosmosDbService
    {
        Task AddItemAsync(RecordingEntity entity);
        Task<IEnumerable<RecordingEntity>> GetItemsAsync(string query);
    }
}

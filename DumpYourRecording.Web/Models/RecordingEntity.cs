using System;
using Newtonsoft.Json;

namespace DumpYourRecording.Web.Models
{
    public class RecordingEntity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "url")]
        public Uri Url { get; set; }
    }
}

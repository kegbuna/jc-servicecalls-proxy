using Newtonsoft.Json;

namespace JCServiceCallsProxy.ServiceCalls
{
    public class Field
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
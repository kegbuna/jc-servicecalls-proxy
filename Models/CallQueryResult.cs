using Newtonsoft.Json;

namespace JCServiceCallsProxy.ServiceCalls
{
    public class CallQueryResult
    {

        [JsonProperty("help")]
        public string Help { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }
    }
}
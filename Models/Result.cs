using System.Collections.Generic;
using Newtonsoft.Json;

namespace JCServiceCallsProxy.ServiceCalls
{
    public class Result
    {

        [JsonProperty("records")]
        public IList<Call> Records { get; set; }

        [JsonProperty("fields")]
        public IList<Field> Fields { get; set; }

        [JsonProperty("sql")]
        public string Sql { get; set; }
    }
}
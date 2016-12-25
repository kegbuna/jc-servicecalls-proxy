using System;
using Newtonsoft.Json;

namespace JCServiceCallsProxy.ServiceCalls
{
    /// <summary>
    /// Represents a call as reported by the JC Data Api
    /// </summary>
    public class Call
    {

        [JsonProperty("Call Type")]
        public string CallType { get; set; }

        [JsonProperty("CITY")]
        public string City { get; set; }

        [JsonProperty("Call Code Description")]
        public string CallCodeDescription { get; set; }

        [JsonProperty("_full_text")]
        public string FullText { get; set; }

        [JsonProperty("District")]
        public string District { get; set; }

        [JsonProperty("CALLCODE")]
        public string CallCode { get; set; }

        [JsonProperty("Time Arrived")]
        public DateTime TimeArrived { get; set; }

        [JsonProperty("SHIFT")]
        public string Shift { get; set; }

        [JsonProperty("UNIT ID")]
        public string UnitId { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Is Primary")]
        public string IsPrimary { get; set; }

        [JsonProperty("LONGITUDE")]
        public float Longitude { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }

        [JsonProperty("Time Received")]
        public DateTime TimeReceived { get; set; }

        [JsonProperty("GEO COUNT")]
        public string GeoCount { get; set; }

        [JsonProperty("Time Dispatched")]
        public DateTime TimeDispatched { get; set; }

        [JsonProperty("LATITUDE")]
        public float Latitude { get; set; }

        [JsonProperty("GEO ERROR")]
        public string GeoError { get; set; }

        [JsonProperty("_id")]
        public int Id { get; set; }

        [JsonProperty("Event Number")]
        public string EventNumber { get; set; }
    }

}
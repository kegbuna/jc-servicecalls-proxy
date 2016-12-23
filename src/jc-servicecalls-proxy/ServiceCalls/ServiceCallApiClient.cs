namespace JCServiceCallsProxy.ServiceCalls
{
    using System;
    using System.Net.Http;

    using Microsoft.Extensions.Options;

    using Newtonsoft.Json;

    /// <summary>
    /// The service call api client.
    /// </summary>
    public class ServiceCallApiClient : IServiceCallApiClient
    {
        private short _limit;

        /// <summary>
        /// The base url.
        /// </summary>
        private string _baseUrl;

        /// <summary>
        /// The http client.
        /// </summary>
        private HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCallApiClient"/> class.
        /// </summary>
        public ServiceCallApiClient(IOptions<CallClientSettings> settings)
        {
            short limit;
            this._httpClient = new HttpClient();
            this._limit = settings.Value.Limit;
            this._baseUrl =
                "http://data.jerseycitynj.gov/api/action/datastore_search_sql?sql=SELECT * FROM \"bf37145d-7282-4271-92b8-db4c92b04dd8\" LIMIT "
                + this._limit;
        }

        /// <summary>
        /// Retrieves a set of calls for the specified period
        /// </summary>
        /// <param name="start">The start of the time period</param>
        /// <param name="end">The end of the time period</param>
        /// <returns><see cref="CallQueryResult"/></returns>
        public CallQueryResult GetCalls(DateTimeOffset start, DateTimeOffset end)
        {
            var calls = this._httpClient.GetStringAsync(this._baseUrl).Result;

            return JsonConvert.DeserializeObject<CallQueryResult>(calls);
        }
        
        /// <summary>
        /// Retrieves a set of calls
        /// </summary>
        /// <returns><see cref="CallQueryResult"/></returns>
        public CallQueryResult GetCalls()
        {
            var calls = this._httpClient.GetStringAsync(this._baseUrl).Result;

            return JsonConvert.DeserializeObject<CallQueryResult>(calls);
        }
    }
}
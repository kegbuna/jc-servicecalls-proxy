// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CallClientSettings.cs" company="Ken Egbuna">
//   2017 Ken Egbuna
// </copyright>
// <summary>
//   Defines the CallClientSettings type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JCServiceCallsProxy.ServiceCalls
{
    using System.Dynamic;

    /// <summary>
    /// The service call client settings.
    /// </summary>
    public class CallClientSettings
    {

        public CallClientSettings()
        {
            this.Limit = 50;
        }

        /// <summary>
        /// The hostname of the server where the API is hosted
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Table to be used in the SQL query
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// The path to the service call API
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets he start of the query
        /// </summary>
        public string BaseQuery { get; set; }

        /// <summary>
        /// The result count limit
        /// </summary>
        public short Limit { get; set; }
    }
}
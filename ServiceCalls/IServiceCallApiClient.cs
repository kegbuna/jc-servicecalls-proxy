// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceCallApiClient.cs" company="Ken Egbuna">
//   2017 by Ken Egbuna
// </copyright>
// <summary>
//   The ServiceCallApiClient interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JCServiceCallsProxy.ServiceCalls
{
    using System;

    /// <summary>
    /// The ServiceCall API Client interface.
    /// </summary>
    public interface IServiceCallApiClient
    {
        /// <summary>
        /// Retrieves a set of calls for the specified period
        /// </summary>
        /// <param name="start">The start of the time period</param>
        /// <param name="end">The end of the time period</param>
        /// <returns><see cref="CallQueryResult"/></returns>
        CallQueryResult GetCalls(DateTimeOffset start, DateTimeOffset end);

        /// <summary>
        /// Retrieves a set of calls
        /// </summary>
        /// <returns><see cref="CallQueryResult"/></returns>
        CallQueryResult GetCalls();
    }
}
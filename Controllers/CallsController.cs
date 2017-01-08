using System;
using JCServiceCallsProxy.ServiceCalls;
using Microsoft.AspNetCore.Mvc;

namespace JCServiceCallsProxy.Controllers
{
    using JCServiceCallsProxy.ServiceCalls;

    [Route("api/[controller]")]
    public class CallsController : Controller
    {
        private readonly IServiceCallApiClient _apiClient;

        public CallsController(IServiceCallApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [Route("")]
        [HttpGet]
        public CallQueryResult GetCalls()
        {
            return _apiClient.GetCalls();
        }

        [Route("{start}/{end}")]
        [HttpGet]
        public CallQueryResult GetByDateRange(DateTimeOffset start, DateTimeOffset end)
        {
            return _apiClient.GetCalls(start, end);
        }
    }
}
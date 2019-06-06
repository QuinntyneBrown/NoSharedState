using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;

namespace NoSharedState
{
    public class Functions
    {
        private readonly IContext _context;
        private readonly IMyService _service;

        public Functions(
            IContext context,
            IMyService service
            )
        {
            _context = context;
            _service = service;
        }

        [FunctionName("Get")]
        public IActionResult Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "get")] HttpRequest req
            )
        {
            this._context.State = "Set";

            return new OkObjectResult(_service.Value);
        }

        [FunctionName("Count")]
        public IActionResult Count(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "count")] HttpRequest req
            )
        {            
            return new OkObjectResult(_service.Count);
        }
    }
}

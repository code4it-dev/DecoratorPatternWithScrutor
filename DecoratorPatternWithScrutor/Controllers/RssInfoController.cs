using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecoratorPatternWithScrutor.Controllers
{
    /*
    -  Installato system.servicemodel.syndication per RSS feed
    - Scrutor (https://www.nuget.org/packages/Scrutor/3.3.0?_src=template)

     */

    [ApiController]
    [Route("[controller]")]
    public class RssInfoController : ControllerBase
    {
        private readonly ILogger<RssInfoController> _logger;

        public RssInfoController(ILogger<RssInfoController> logger)
        {
            _logger = logger;
        }
    }
}
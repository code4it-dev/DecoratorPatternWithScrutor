using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace DecoratorPatternWithScrutor.Controllers
{

    public interface IRssFeedReader
    {
        RssItem GetItem(string slug);
    }
}
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

    public class RssFeedReader : IRssFeedReader
    {
        public RssItem GetItem(string slug)
        {
            var url = "https://www.code4it.dev/rss.xml";
            using var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);

            SyndicationItem item = feed.Items.FirstOrDefault(item => item.Id.EndsWith(slug));
            if (item == null) return null;
            return new RssItem
            {
                Title = item.Title.Text,
                Url = item.Links.First().Uri.AbsoluteUri
            };
        }
    }
}
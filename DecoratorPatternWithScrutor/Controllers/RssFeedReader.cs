using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.ServiceModel.Syndication;
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

    public class CachedFeedReader : IRssFeedReader
    {
        private readonly IRssFeedReader _rssFeedReader;
        private readonly IMemoryCache _memoryCache;

        public CachedFeedReader(IRssFeedReader rssFeedReader, IMemoryCache memoryCache)
        {
            _rssFeedReader = rssFeedReader;
            _memoryCache = memoryCache;
        }

        public RssItem GetItem(string slug)
        {
            var isFromCache = _memoryCache.TryGetValue(slug, out RssItem item);
            if (!isFromCache)
            {
                item = _rssFeedReader.GetItem(slug);
            }
            item.IsFromCache = isFromCache;

            _memoryCache.Set(slug, item);
            return item;
        }
    }
}
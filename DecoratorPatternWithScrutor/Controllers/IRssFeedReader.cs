namespace DecoratorPatternWithScrutor.Controllers
{
    public interface IRssFeedReader
    {
        RssItem GetItem(string slug);
    }
}
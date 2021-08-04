namespace DecoratorPatternWithScrutor.Controllers
{
    public class RssItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsFromCache { get; set; }
    }
}
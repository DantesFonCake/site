using Piranha.Extend;
using Piranha.Extend.Fields;

namespace web1.Models.Blocks
{
    [BlockType(Name = "Youtube", Category = "Media", Icon = "fab fa-youtube", IsGeneric = true)]
    public class YoutubeBlock : Block
    {
        private string url;

        [Field(Title = "Video URL")]
        public StringField VideoUrl
        {
            get => url;
            set
            {
                url = value;
                if (url != null)
                {
                    var queryString = new System.Uri(url).Query;
                    System.Collections.Specialized.NameValueCollection queryDictionary = System.Web.HttpUtility.ParseQueryString(queryString);
                    VideoId = queryDictionary.Get("v");
                }
            }
        }

        public string VideoId { get; private set; }

        public override string GetTitle()
        {
            return !string.IsNullOrEmpty(VideoId) ? url : "No video id provided";
        }
    }
}

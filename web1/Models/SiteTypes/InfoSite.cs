using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;
using System.Collections.Generic;

namespace web1.Models.SiteTypes
{
    [SiteType(Title = "Info site")]
    public class InfoSite : SiteContent<InfoSite>
    {
        

        [Region(Title = "Footer", Display = RegionDisplayMode.Setting,ListTitle ="Footer columns")]
        public IList<HtmlField> FooterContents { get; set; }
    }
}

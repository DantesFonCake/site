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

        [Region(Title = "Title", Display = RegionDisplayMode.Setting)]
        public StringField NavTitle { get; set; }

        [Region(Title = "Footer", Display = RegionDisplayMode.Setting)]
        public TextField FooterContents { get; set; }

        [Region(Title = "Additional CSS", Display = RegionDisplayMode.Setting)]
        public IList<DocumentField> CssList { get; set; }
    }
}

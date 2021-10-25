using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web1.Models
{
    [PageType(UseBlocks =false,Title ="Map",UseExcerpt =false)]
    [ContentTypeRoute(Title = "Default", Route = "/map")]
    public class MapPage:Page<MapPage>
    {
        [Region(Title = "Post",Display =RegionDisplayMode.Content)]
        public PostField Post { get; set; }

        [Region(Title = "Post2", Display = RegionDisplayMode.Content)]
        public PostField Post2 { get; set; }
    }
}

using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;
using System.Collections.Generic;

namespace web1.Models;

[PageType(UseBlocks = false, Title = "Map", UseExcerpt = false)]
[ContentTypeRoute(Title = "Default", Route = "/map")]
public class MapPage : Page<MapPage>
{
    [Region(Title = "Buildings", ListTitle = nameof(Building.SvgId), Display = Piranha.Models.RegionDisplayMode.Content)]
    public IList<Building> Buildings { get; set; }
}
public class Building
{
    [Field(Title = "Svg Id", Description = "Id for area on svg")]
    public StringField SvgId { get; set; }

    [Field(Title = "Human Name", Description = "Human readable name for area")]
    public StringField HumanName { get; set; }

    [Field(Title = "Popup post", Description = "Post that will be used for popup")]
    public PostField Post { get; set; }
}

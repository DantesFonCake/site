using Piranha.AttributeBuilder;
using Piranha.Models;

namespace web1.Models
{
    [PageType(UseBlocks = false, Title = "River Map", UseExcerpt = false)]
    [ContentTypeRoute(Title = "Default", Route = "/rivermap")]
    public class RiverMapPage : Page<RiverMapPage>
    {

    }
}

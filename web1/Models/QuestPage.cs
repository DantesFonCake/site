using Piranha.AttributeBuilder;
using Piranha.Models;

namespace web1.Models;

[PageType(UseBlocks = false, Title = "Quest", UseExcerpt = false)]
[ContentTypeRoute(Title = "Default", Route = "/quest")]
public class QuestPage : Page<QuestPage>
{
}

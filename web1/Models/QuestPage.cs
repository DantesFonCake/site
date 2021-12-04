using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using System.Linq;
using web1.Models.Blocks;

namespace web1.Models;

[PageType(UseBlocks = false, Title = "Quest", UseExcerpt = false)]
[BlockItemType(typeof(EventBlock))]
[BlockItemType(typeof(ActionBlock))]
[ContentTypeRoute(Title = "Default", Route = "/quest")]
public class QuestPage : Page<QuestPage>
{
    public object Serialize()
    {
        return Blocks.Where(x => x is EventBlock)
            .Select(x => x as EventBlock)
            .Select(x =>
                new
                {
                    title = x.Title.Value,
                    id = x.EventId.Value,
                    actions = x.Items
                        .Select(y => y as ActionBlock)
                        .Select(y => new { 
                                text = y.Text.Value,
                                next_id = y.NextId.Value,
                            }).ToArray()
                })
            .ToArray();
    }
}

using Piranha.AttributeBuilder;
using Piranha.Models;

namespace web1.Models
{
    [PostType(Title = "Standard post")]
    public class StandardPost : Post<StandardPost>
    {
    }
}
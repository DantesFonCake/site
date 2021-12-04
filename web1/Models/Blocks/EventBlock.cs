using Piranha.Extend;
using Piranha.Extend.Fields;

namespace web1.Models.Blocks;

[BlockGroupType(Name = "Question", Category = "Quest", Icon = "fas fa-question", IsGeneric = true)]
[BlockItemType(Type = typeof(ActionBlock))]
public class EventBlock : BlockGroup
{
    [Field(Description = "Номер этого события", Title = "Номер")]
    public NumberField EventId { get; set; }

    [Field(Description = "Текст", Title = "Событие")]
    public HtmlField Title { get; set; }

    public override string GetTitle()
    {
        return Title;
    }
}

[BlockType(Name = "Answer", Category = "Quest", Icon = "fas fa-exclamation", IsGeneric = true)]
public class ActionBlock : Block
{
    public override string GetTitle()
    {
        return Text;
    }

    [Field(Description = "Номер слудующего события", Title = "Следующее")]
    public NumberField NextId { get; set; }

    [Field(Title = "Вариант ответа")]
    public HtmlField Text { get; set; }
}

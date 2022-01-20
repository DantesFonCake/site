using Piranha.Extend;
using Piranha.Extend.Fields;

namespace web1.Models.Blocks
{
    [BlockGroupType(Name = "Question", Category = "Quest", Icon = "fas fa-question", IsGeneric = true)]
    [BlockItemType(Type = typeof(ActionBlock))]
    public class EventBlock : BlockGroup
    {
        [Field(Title = "Номер")]
        [FieldDescription("Номер этого события")]
        public NumberField EventId { get; set; }

        [Field(Title = "Событие")]
        [FieldDescription("Текст")]
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

        [Field(Title = "Следующее")]
        [FieldDescription("Номер следующего события")]
        public NumberField NextId { get; set; }

        [Field(Title = "Вариант ответа")]
        public HtmlField Text { get; set; }
    }
}
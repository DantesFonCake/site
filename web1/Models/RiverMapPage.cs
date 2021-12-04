using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;
using System.Collections.Generic;

namespace web1.Models;

[PageType(UseBlocks = false, Title = "River Map", UseExcerpt = false)]
[ContentTypeRoute(Title = "Default", Route = "/rivermap")]
public class RiverMapPage : Page<RiverMapPage>
{
    [Region(Title="Города",ListTitle =nameof(City.Name))]
    public IList<City> Cities { get; set; }
}

public class City
{
    [Field(Title = "Название", Description ="Название города")]
    public StringField Name { get; set; }

    [Field(Title = "X координата", Description = "X координата положения названия, не менять без крайней необходимости")]
    public NumberField XText { get; set; }

    [Field(Title = "Y координата", Description = "Y координата положения названия, не менять без крайней необходимости")]
    public NumberField YText { get; set; }

    [Field(Title = "Положение", Description = "Положение города, не менять без крайней необходимости")]
    public NumberField Position { get; set; }

    [Field(Title ="Попап")]
    public PostField Post { get; set; }
}

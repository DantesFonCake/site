using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;
using System.Collections.Generic;

namespace web1.Models
{
    [PageType(UseBlocks = false, Title = "Map", UseExcerpt = false)]
    [ContentTypeRoute(Title = "Default", Route = "/map")]
    public class MapPage : Page<MapPage>
    {
        [Region(Title = "Buildings", ListTitle = nameof(Building.HumanName), Display = Piranha.Models.RegionDisplayMode.Content)]
        public IList<Building> Buildings { get; set; }
    }
    public class Building
    {
        [Field(Title = "Name")]
        [FieldDescription(Text = "Css class name for area")]
        public StringField Name { get; set; }

        [Field(Title = "Human Name")]
        [FieldDescription(Text = "Human readable name for area")]
        public StringField HumanName { get; set; }

        [Field(Title = "Coordinates")]
        [FieldDescription(Text = "Coordinates separated by comma e.q. \"105,128,164,417\"")]
        public StringField Coords { get; set; }

        //TODO: when Cannot access disposed IServiceProvider #1701 fixed change ShapeName to this
        //[Field(Title = "Shape")]
        //public SelectField<ShapeType> ShapeName { get; set; } //not implemented properly, can't save page in manager

        [Field(Title = "Shape")]
        public StringField ShapeName { get; set; }

        [Field(Title = "Popup post")]
        public PostField Post { get; set; }
    }

    //public enum ShapeType
    //{
    //    Rectangle,
    //    Polygon
    //}
}

using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model
{
    [JsonEnumConverterAttribute]
    public enum BorderSkipped
    {
        False,
        Start,
        End,
        Left,
        Right,
        Bottom,
        Top
    }
}
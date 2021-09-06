using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model
{
    [JsonEnumConverter]
    public enum CanvasLineCap
    {
        Butt,
        Round,
        Square
    }
}
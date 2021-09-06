using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PointStyleEnum
    {
        Circle,
        Cross,
        CrossRot,
        Dash,
        Line,
        Rect,
        RectRounded,
        RectRot,
        Star,
        Triangle,
        ImageElement,
        CanvasElement
    }
}
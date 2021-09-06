using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Stepped
    {
        False,
        True,
        Before,
        After,
        Middle
    }
}
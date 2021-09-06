using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model.ChartTypes
{
    [JsonConverter(typeof(ChartTypeConverter))]
    public enum ChartTypeEnum
    {
        Line,
        Bar,
        Radar,
        Doughnut,
        Pie,
        PolarArea,
        Bubble,
        Scatter
    }
}
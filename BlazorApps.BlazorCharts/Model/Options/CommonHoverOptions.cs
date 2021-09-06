using BlazorApps.BlazorCharts.Model.Options.Interfaces;
using System.Drawing;
using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model.Options
{
    public class CommonHoverOptions : IChartOptions
    {
        [JsonConverter(typeof(ChartColorConverter))]
        public Color HoverBackgroundColor { get; set; }
        [JsonConverter(typeof(ChartColorConverter))]
        public Color HoverBorderColor { get; set; }
        public double HoverBorderWidth { get; set; }
    }
}
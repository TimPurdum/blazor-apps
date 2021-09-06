using BlazorApps.BlazorCharts.Model.Options.Interfaces;
using System;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model.Options
{
    public interface ICommonElementOptions : IChartOptions
    {
        [JsonConverter(typeof(ChartColorConverter))]
        Color? BackgroundColor { get; set; }
        [JsonConverter(typeof(ChartColorConverter))]
        Color? BorderColor { get; set; }
        double? BorderWidth { get; set; }
    }
}
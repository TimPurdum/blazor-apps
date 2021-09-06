using BlazorApps.BlazorCharts.Model.Options.Interfaces;

namespace BlazorApps.BlazorCharts.Model.Options
{
    public class ParsingOptions : IChartOptions
    {
        public bool Normalized { get; set; }
        public Parsing Parsing { get; set; }
    }
}
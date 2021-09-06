using System.Collections.Generic;

namespace BlazorApps.BlazorCharts
{
    public class ChartConfiguration
    {
        public ChartType ChartType { get; set; }
        public ChartData Data { get; set; }
        public IReadOnlyList<IChartOptions> Options { get; set; }
    }
}
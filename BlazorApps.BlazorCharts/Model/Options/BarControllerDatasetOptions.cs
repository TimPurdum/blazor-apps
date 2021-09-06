using BlazorApps.BlazorCharts.Model.ChartTypes;
using BlazorApps.BlazorCharts.Model.Options.Interfaces;

namespace BlazorApps.BlazorCharts.Model.Options
{
    public class BarControllerDatasetOptions : ControllerDatasetOptions, IAnimationOptions<BarChartType>
    {
        public Animation Animation { get; set; }
    }
}
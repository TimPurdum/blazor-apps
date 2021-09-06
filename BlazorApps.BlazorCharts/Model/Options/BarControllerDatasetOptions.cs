namespace BlazorApps.BlazorCharts
{
    public class BarControllerDatasetOptions : ControllerDatasetOptions, IAnimationOptions<BarChartType>
    {
        public Animation Animation { get; set; }
    }
}
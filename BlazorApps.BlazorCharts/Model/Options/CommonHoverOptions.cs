using System.Drawing;

namespace BlazorApps.BlazorCharts
{
    public class CommonHoverOptions : IChartOptions
    {
        public Color HoverBackgroundColor { get; set; }
        public Color HoverBorderColor { get; set; }
        public double HoverBorderWidth { get; set; }
    }
}
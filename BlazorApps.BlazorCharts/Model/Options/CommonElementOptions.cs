using System.Drawing;

namespace BlazorApps.BlazorCharts
{
    public class CommonElementOptions : IChartOptions
    {
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
        public double BorderWidth { get; set; }
    }
}
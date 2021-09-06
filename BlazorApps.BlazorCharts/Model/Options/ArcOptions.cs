using BlazorApps.BlazorCharts.Model.Enums;

namespace BlazorApps.BlazorCharts.Model.Options
{
    public interface IArcOptions
    {
        public ArcStrokeAlignment BorderAlign { get; set; }
        public ArcBorderRadius BorderRadius { get; set; }
        public double Offset { get; set; }
    }
}
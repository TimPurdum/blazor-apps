using BlazorApps.BlazorCharts.Model.Enums;

namespace BlazorApps.BlazorCharts.Model.Options
{
    public interface IBarOptions
    {
        public double Base { get; set; }
        public BorderRadius BorderRadius { get; set; }
        public BorderSkipped BorderSkipped { get; set; }
    }
}
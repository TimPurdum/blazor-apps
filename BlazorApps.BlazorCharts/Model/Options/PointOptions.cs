namespace BlazorApps.BlazorCharts.Model.Options
{
    public interface IPointOptions
    {
        public double HitRadius { get; set; }
        public PointStyle PointStyle { get; set; }
        public double Radius { get; set; }
        public double Rotation { get; set; }
    }
}
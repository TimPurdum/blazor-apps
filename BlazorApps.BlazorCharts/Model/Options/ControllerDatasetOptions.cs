namespace BlazorApps.BlazorCharts.Model.Options
{
    public class ControllerDatasetOptions : ParsingOptions
    {
        public ChartArea Clip { get; set; }
        public bool Hidden { get; set; }
        public Axis IndexAxis { get; set; }
        public string Label { get; set; }
        public double Order { get; set; }
        public string Stack { get; set; }
    }
}
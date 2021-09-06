namespace BlazorApps.BlazorCharts.Model
{
    /// <summary>
    ///     Each parameter is a scriptable function to be passed to javascript, with a 'context' param
    /// </summary>
    public class Segment
    {
        public string BackgroundColor { get; set; } 
        public string BorderCapStyle { get; set; }
        public string BorderColor { get; set; }
        public string BorderDash { get; set; }
        public string BorderDashOffset { get; set; }
        public string BorderJoinStyle { get; set; }
        public string BorderWidth { get; set; }
    }
}
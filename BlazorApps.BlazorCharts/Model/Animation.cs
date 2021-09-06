namespace BlazorApps.BlazorCharts
{
    public class Animation
    {
        public bool IsEnabled { get; set; }
        public string? OnComplete { get; set; }
        public string? OnProgress { get; set; }
        public string? Delay { get; set; }
        public string? Duration { get; set; }
        public string? Easing { get; set; }
        public string? Loop { get; set; }
    }
}
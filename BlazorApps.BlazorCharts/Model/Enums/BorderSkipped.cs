namespace BlazorApps.BlazorCharts.Model.Enums
{
    [JsonEnumConverter]
    public enum BorderSkipped
    {
        False,
        Start,
        End,
        Left,
        Right,
        Bottom,
        Top
    }
}
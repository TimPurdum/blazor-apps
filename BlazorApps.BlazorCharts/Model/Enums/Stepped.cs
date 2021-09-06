namespace BlazorApps.BlazorCharts.Model.Enums
{
    [JsonEnumConverter]
    public enum Stepped
    {
        False,
        True,
        Before,
        After,
        Middle
    }
}
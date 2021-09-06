namespace BlazorApps.BlazorCharts.Model
{
    public interface IChartConvertibleObject
    {
        virtual string ToJavascriptString()
        {
            return ToString();
        }
    }
}
namespace BlazorApps.BlazorCharts
{
    public interface IChartConvertibleObject
    {
        virtual string ToJavascriptString()
        {
            return ToString();
        }
    }
}
namespace BlazorApps.BlazorCharts.Model
{
    public class NumberDataPoint: DataPoint
    {
        public NumberDataPoint(double value)
        {
            Value = value;
        }

        public double Value { get; }
    }
}
using System.Collections.Generic;

namespace BlazorApps.BlazorCharts
{
    public class BarChartType: IChartType
    {
        public string Identifier => "bar";
        public IReadOnlyList<IChartOptions> ChartOptions { get; }
        public IReadOnlyList<IDataSetOptions> DataSetOptions { get; }
        public IDataPoint DefaultDataPoint { get; }
        public IMetaExtensions MetaExtensions { get; }
    }
}
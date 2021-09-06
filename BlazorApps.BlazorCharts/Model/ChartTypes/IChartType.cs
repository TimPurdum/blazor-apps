using System.Collections.Generic;

namespace BlazorApps.BlazorCharts
{
    public interface IChartType
    {
        string Identifier { get; }
        IReadOnlyList<IChartOptions> ChartOptions { get; }
        IReadOnlyList<IDataSetOptions> DataSetOptions { get; }
        IDataPoint DefaultDataPoint { get; }
        IMetaExtensions MetaExtensions { get; }
    }
}
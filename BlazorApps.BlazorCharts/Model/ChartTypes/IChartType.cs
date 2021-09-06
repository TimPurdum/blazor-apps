using BlazorApps.BlazorCharts.Model.Options.Interfaces;
using System.Collections.Generic;

namespace BlazorApps.BlazorCharts.Model.ChartTypes
{
    public interface IChartType
    {
        string Identifier { get; }
        IReadOnlyList<IChartOptions> ChartOptions { get; }
        IReadOnlyList<IDataSetOptions> DataSetOptions { get; }
        DataPoint DefaultDataPoint { get; }
        IMetaExtensions MetaExtensions { get; }
    }
}
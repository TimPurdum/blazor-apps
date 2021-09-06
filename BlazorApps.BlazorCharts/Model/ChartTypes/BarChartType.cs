using BlazorApps.BlazorCharts.Model.Options.Interfaces;
using System.Collections.Generic;

namespace BlazorApps.BlazorCharts.Model.ChartTypes
{
    public class BarChartType: IChartType
    {
        public string Identifier => "bar";
        public IReadOnlyList<IChartOptions> ChartOptions { get; }
        public IReadOnlyList<IDataSetOptions> DataSetOptions { get; }
        public DataPoint DefaultDataPoint { get; }
        public IMetaExtensions MetaExtensions { get; }
    }
}
using BlazorApps.BlazorCharts.Model.Options.Interfaces;
using System.Collections.Generic;

namespace BlazorApps.BlazorCharts.Model.ChartTypes
{
    public class BarChartType: IChartType
    {
        public string Identifier => "bar";
        public IReadOnlyList<IChartOptions> ChartOptions { get; } = new List<IChartOptions>();
        public IReadOnlyList<IDataSetOptions> DataSetOptions { get; } = new List<IDataSetOptions>();
        public DataPoint DefaultDataPoint { get; } = new DataPoint();
        public IMetaExtensions? MetaExtensions { get; }
    }
}
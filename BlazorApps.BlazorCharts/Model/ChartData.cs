using System.Collections.Generic;

namespace BlazorApps.BlazorCharts
{
    public class ChartData
    {
        public IReadOnlyList<string> Labels { get; set; }
        public IReadOnlyList<DataSet> DataSets { get; set; }
    }
}
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model
{
    public class ChartData
    {
        public IReadOnlyList<string> Labels { get; set; }
        [JsonPropertyName("datasets")]
        public IReadOnlyList<DataSet> DataSets { get; set; }
    }
}
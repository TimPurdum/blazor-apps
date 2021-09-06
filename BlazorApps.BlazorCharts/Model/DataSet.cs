using System.Collections.Generic;
using System.Drawing;

namespace BlazorApps.BlazorCharts
{
    public class DataSet
    {
        public string Label { get; set; }
        public IReadOnlyList<IDataPoint> Data { get; set; }
        public Color BorderColor { get; set; }
        public Color BackgroundColor { get; set; }
    }
}
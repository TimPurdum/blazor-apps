using System.Drawing;
using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model
{
    public class ComplexFillTarget: IFillTarget
    {
        public FillTarget Target { get; set; }
        [JsonConverter(typeof(ChartColorConverter))]
        public Color Above { get; set; }
        [JsonConverter(typeof(ChartColorConverter))]
        public Color Below { get; set; }
    }
}
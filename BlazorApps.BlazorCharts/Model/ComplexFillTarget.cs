using System.Drawing;

namespace BlazorApps.BlazorCharts
{
    public class ComplexFillTarget: IFillTarget
    {
        public FillTarget Target { get; set; }
        public Color Above { get; set; }
        public Color Below { get; set; }
    }
}
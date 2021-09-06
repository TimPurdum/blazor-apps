using System.Collections.Generic;

namespace BlazorApps.BlazorCharts
{
    public class LineHoverOptions : CommonHoverOptions
    {
        public CanvasLineCap HoverBorderCapStyle { get; set; }
        public IReadOnlyList<double> HoverBorderDash { get; set; }
        public double HoverBorderDashOffset { get; set; }
        public CanvasLineJoin HoverBorderJoinStyle { get; set; }
    }
}
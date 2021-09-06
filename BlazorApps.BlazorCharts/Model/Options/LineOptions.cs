using System.Collections.Generic;

namespace BlazorApps.BlazorCharts
{
    public class LineOptions : CommonElementOptions
    {
        public CanvasLineCap BorderCapStyle { get; set; }
        public IReadOnlyList<double> BorderDash { get; set; }
        public double BorderDashOffset { get; set; }
        public CanvasLineJoin BorderJoinStyle { get; set; }
        public bool CapBezierPoints { get; set; }
        public CubicInterpolationMode CubicInterpolationMode { get; set; }
        public IFillTarget Fill { get; set; }
        public Segment Segment { get; set; }
        public Stepped Stepped { get; set; }
        public double Tension { get; set; }
    }
}
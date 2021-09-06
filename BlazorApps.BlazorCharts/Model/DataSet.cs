using BlazorApps.BlazorCharts.Model.Enums;
using BlazorApps.BlazorCharts.Model.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model
{
    [JsonConverter(typeof(DataSetConverter))]
    public class DataSet: ICommonElementOptions
    {
        public string Label { get; set; }
        public IReadOnlyList<DataPoint> Data { get; set; }
        [JsonConverter(typeof(ChartColorConverter))]
        public Color? BackgroundColor { get; set; }
        [JsonConverter(typeof(ChartColorConverter))]
        public Color? BorderColor { get; set; }
        public double? BorderWidth { get; set; }
    }

    
    public class LineDataSet : DataSet, ILineOptions
    {
        public CanvasLineCap? BorderCapStyle { get; set; }
        public IReadOnlyList<double>? BorderDash { get; set; }
        public double? BorderDashOffset { get; set; }
        public CanvasLineJoin? BorderJoinStyle { get; set; }
        public bool? CapBezierPoints { get; set; }
        public CubicInterpolationMode? CubicInterpolationMode { get; set; }
        public IFillTarget? Fill { get; set; }
        public Segment? Segment { get; set; }
        public Stepped? Stepped { get; set; }
        public double? Tension { get; set; }
    }

    public class BarDataSet : DataSet, IBarOptions
    {
        public double Base { get; set; }
        public BorderRadius BorderRadius { get; set; }
        public BorderSkipped BorderSkipped { get; set; }
    }


    public class DataSetConverter : JsonConverter<DataSet>
    {
        public override DataSet? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, DataSet value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
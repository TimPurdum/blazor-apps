using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model
{
    [JsonConverter(typeof(DataPointConverter))]
    public class DataPoint
    {
        
    }

    public class DataPointConverter : JsonConverter<DataPoint>
    {
        public override DataPoint? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, DataPoint value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case BubbleDataPoint bubbleDataPoint:
                    writer.WriteNumber("x", bubbleDataPoint.X);
                    writer.WriteNumber("y", bubbleDataPoint.Y);
                    writer.WriteNumber("r", bubbleDataPoint.R);
                    break;
                case ActiveDataPoint activeDataPoint:
                    writer.WriteNumber("datasetIndex", activeDataPoint.DatasetIndex);
                    writer.WriteNumber("index", activeDataPoint.Index);
                    break;
                case NumberDataPoint numberDataPoint:
                    writer.WriteNumberValue(numberDataPoint.Value);
                    break;
                case ScatterDataPoint scatterDataPoint:
                    writer.WriteNumber("x", scatterDataPoint.X);
                    writer.WriteNumber("y", scatterDataPoint.Y);
                    break;
            }
        }
    }
}
using System;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model
{
    public class ChartColorConverter: JsonConverter<Color>
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"rgba({value.R},{value.G},{value.B},{value.A / 255})");
        }
    }
}
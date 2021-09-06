using BlazorApps.BlazorCharts.Model.ChartTypes;
using BlazorApps.BlazorCharts.Model.Options.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model
{
    public class ChartConfiguration
    {
        [JsonPropertyName("type")]
        public ChartTypeEnum ChartType { get; set; }
        public ChartData Data { get; set; }
        [JsonPropertyName("options")]
        public IReadOnlyList<IChartOptions> Options { get; set; }
    }

    public class ChartTypeConverter : JsonConverter<ChartTypeEnum>
    {
        public override ChartTypeEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, ChartTypeEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString().ToCamelCase());
        }
    }


    public static class StringFormatExtensions
    {
        public static string ToCamelCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            return char.ToLower(str[0]) + str.Substring(1);
        }
    }
}
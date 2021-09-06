using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApps.BlazorCharts.Model
{
    public class JsonEnumConverterAttribute : JsonConverterAttribute
    {
        public override JsonConverter? CreateConverter(Type typeToConvert)
        {
            return new JsonStringEnumConverter(JsonNamingPolicy.CamelCase);
        }
    }
}
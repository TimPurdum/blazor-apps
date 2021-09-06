using System.Text;

namespace BlazorApps.BlazorCharts.Model
{
    public class DoubleValueOrObject: IChartConvertibleObject
    {
        public double? Value { get; }
        
        public string ToJavascriptString()
        {
            if (Value.HasValue)
            {
                return Value.ToString();
            }

            var type = this.GetType();
            var props = type.GetProperties();
            _sb.Clear();
            foreach (var prop in props)
            {
                if (prop.Name == "Value") continue;
                var propVal = prop.GetValue(this);
                if (propVal == null) continue;
                _sb.Append($"{prop.Name.ToLower()}: {propVal}");
            }

            return _sb.ToString();
        }

        private readonly StringBuilder _sb = new StringBuilder();
    }
}
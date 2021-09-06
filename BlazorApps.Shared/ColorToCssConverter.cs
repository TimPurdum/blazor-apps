using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApps.Shared
{
    public static class ColorConverter
    {
        public static string GetCssColor(Color systemColor)
        {
            return $"rgba({systemColor.R},{systemColor.G},{systemColor.B},{systemColor.A / 255})";
        }

        public static Color GetSystemColor(string cssColor)
        {
            try
            {
                if (cssColor.StartsWith("rgb"))
                {
                    var valueString = cssColor.Substring(cssColor.IndexOf('(') + 1).Trim(')', ';');
                    var values = valueString.Split(',');
                    var r = int.Parse(values[0].Trim());
                    var g = int.Parse(values[1].Trim());
                    var b = int.Parse(values[2].Trim());
                    var a = 255;
                    if (values.Length > 3)
                    {
                        a = (int) (double.Parse(values[3].Trim()) * 255);
                    }

                    return Color.FromArgb(a, r, g, b);
                }
                else if (cssColor.StartsWith("#"))
                {
                    var hashValue = cssColor.Substring(1).Trim();
                    var r = Convert.ToInt32(hashValue.Substring(0, 2), 16);
                    var g = Convert.ToInt32(hashValue.Substring(2, 2), 16);
                    var b = Convert.ToInt32(hashValue.Substring(4, 2), 16);
                    var a = 255;
                    if (hashValue.Length == 8)
                    {
                        a = Convert.ToInt32(hashValue.Substring(6, 2), 16);
                    }

                    return Color.FromArgb(a, r, g, b);
                }

                return ColorTranslator.FromHtml(cssColor);
            }
            catch (Exception ex)
            {
                throw new InvalidCssColorException(cssColor, ex);
            }
        }
    }

    public class InvalidCssColorException : Exception
    {
        public InvalidCssColorException(string value, Exception? innerException = null) 
            : base($"The value {value} could not be parsed as a css color.", innerException) 
        {
        }
    }
}

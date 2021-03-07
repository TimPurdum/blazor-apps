namespace BlazorDataGrid.Business
{
    public static class CssConverter
    {
        public static string Measurement(MeasurementUnit mu, int value)
        {
            switch (mu)
            {
                case MeasurementUnit.Em:
                    return $"{value}em";
                case MeasurementUnit.Percent:
                    return $"{value}%";
                case MeasurementUnit.Pixel:
                    return $"{value}px";
                case MeasurementUnit.ViewHeight:
                    return $"{value}vh";
                case MeasurementUnit.ViewWidth:
                    return $"{value}vw";
                case MeasurementUnit.Auto:
                    return "auto";
            }

            return string.Empty;
        }


        public static string ColumnWidthMeasurement(ColumnMeasurementUnit mu, int value)
        {
            switch (mu)
            {
                case ColumnMeasurementUnit.Percent:
                    return $"{value}%";
                default:
                    return $"{value}px";
            }

            return string.Empty;
        }
    }
}
﻿using BlazorDataGrid.Business.Components;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDataGrid.Business
{
    public class BdColumnDefinition: BdGridComponent
    {
        public string BindingField { get; set; } = null!;

        public FieldType? FieldType { get; set; }

        public string? Header { get; set; }

        public int Width
        {
            get => _width;
            set
            {
                if (value != _width)
                {
                    _width = value;
                    StyleChanged = true;
                }
            }
        }

        public ColumnMeasurementUnit WidthUnit
        {
            get => _widthUnit;
            set
            {
                if (value != _widthUnit)
                {
                    _widthUnit = value;
                    StyleChanged = true;
                }
            }
        }

        public override async Task BuildStyle(StringBuilder? builder = null)
        {
            if (!StyleChanged)
            {
                return;
            }

            builder ??= new StringBuilder();
            builder.Append($"width:{CssConverter.ColumnWidthMeasurement(WidthUnit, Width)}; ");
            await base.BuildStyle(builder);
            StyleChanged = false;
        }


        private int _width = 100;
        private ColumnMeasurementUnit _widthUnit = ColumnMeasurementUnit.Auto;
    }
}
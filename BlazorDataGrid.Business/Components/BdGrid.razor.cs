using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDataGrid.Business.Components
{
    public partial class BdGrid<TItem>
    {
        [Parameter]
        public IList<TItem> ItemsSource { get; set; } = new List<TItem>();


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            var itemSourceType = ItemsSource.GetType();
            var itemType = itemSourceType.IsGenericType
                ? itemSourceType.GetGenericArguments()[0]
                : itemSourceType.GetElementType();
            if (itemType == null)
            {
                throw new InvalidItemsSourceException(itemSourceType?.Name);
            }

            var properties = itemType.GetProperties();
            if (AutoGenerateColumns)
            {
                foreach (var prop in properties)
                {
                    if (ColumnDefinitions.All(c => c.BindingField != prop.Name))
                    {
                        var col = new BdColumnDefinition
                        {
                            BindingField = prop.Name,
                            Header = (prop.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute)?
                                .DisplayName ?? prop.Name,
                            FieldType = SetFieldType(prop.PropertyType)
                        };
                        ColumnDefinitions.Add(col);
                    }
                }
            }
            else
            {
                foreach (var col in ColumnDefinitions)
                {
                    var prop = properties.FirstOrDefault(p => p.Name == col.BindingField);
                    if (prop != null)
                    {
                        col.FieldType ??= SetFieldType(prop.PropertyType);
                        col.Header ??= (prop.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute)?
                            .DisplayName ?? prop.Name;
                    }
                }
            }

            CalculateAutomaticWidths();
        }

        private FieldType? SetFieldType(Type propType)
        {
            switch (propType.Name.ToLowerInvariant())
            {
                case "int":
                    return FieldType.IntNumeric;
                case "double":
                case "float":
                    return FieldType.DoubleNumeric;
                case "datetime":
                    return FieldType.DateTimeLocal;
                case "bool":
                    return FieldType.Checkbox;
                default: 
                    return FieldType.Text;
            }
        }
    }

    public class BdGridBase : BdGridComponent
    {
        [Parameter]
        public bool AutoGenerateColumns { get; set; } = true;

        [Parameter]
        public IList<BdColumnDefinition> ColumnDefinitions { get; set; } = new List<BdColumnDefinition>();

        [Parameter]
        public int Height { get; set; }

        [Parameter]
        public MeasurementUnit? HeightUnit { get; set; } = MeasurementUnit.Pixel;

        [Parameter]
        public int RowHeight { get; set; }

        [Parameter]
        public MeasurementUnit? RowHeightUnit { get; set; }

        [Parameter]
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


        [Parameter]
        public MeasurementUnit? WidthUnit { get; set; } = MeasurementUnit.Pixel;


        public override async Task BuildStyle(StringBuilder? builder = null)
        {
            if (!StyleChanged)
            {
                return;
            }

            builder ??= new StringBuilder();
            if (WidthUnit.HasValue)
            {
                builder.Append($"width:{CssConverter.Measurement(WidthUnit.Value, Width)}; ");
            }

            if (HeightUnit.HasValue)
            {
                builder.Append($"height:{CssConverter.Measurement(HeightUnit.Value, Height)}; ");
            }

            Style = builder.ToString();
            StyleChanged = false;
            //await InvokeAsync(StateHasChanged);
        }


        protected void CalculateAutomaticWidths()
        {
            _tokenSource.Cancel();
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;
            var pxTotal = 0.0;
            var freeColumns = new List<BdColumnDefinition>();
            foreach (var col in ColumnDefinitions)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }

                switch (col.WidthUnit)
                {
                    case ColumnMeasurementUnit.Pixel:
                        pxTotal += col.Width;
                        break;
                    case ColumnMeasurementUnit.Percent:
                        pxTotal += Width * (col.Width * 0.01);
                        break;
                    default:
                        freeColumns.Add(col);
                        break;
                }
            }

            var freeWidth = Width - pxTotal;
            var autoWidth = freeWidth / freeColumns.Count;
            // measure defined columns first
            foreach (var col in freeColumns)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }

                col.Width = (int) autoWidth;
            }
        }

        private static CancellationTokenSource _tokenSource = new();
        private int _width;
    }
}
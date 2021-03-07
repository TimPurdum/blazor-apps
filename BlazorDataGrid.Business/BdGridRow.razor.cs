using BlazorDataGrid.Business.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDataGrid.Business
{
    public partial class BdGridRow<TItem> : BdGridComponent
    {
        [CascadingParameter(Name = "ColumnDefinitions")]
        public IList<BdColumnDefinition> ColumnDefinitions { get; set; } = new List<BdColumnDefinition>();

        [Parameter]
        public TItem? Item { get; set; }

        [CascadingParameter(Name = "RowHeight")]
        public int RowHeight { get; set; }

        [CascadingParameter(Name = "RowHeightUnit")]
        public MeasurementUnit? RowHeightUnit { get; set; }


        public override async Task BuildStyle(StringBuilder? builder = null)
        {
            if (!StyleChanged)
            {
                return;
            }

            builder ??= new StringBuilder();
            if (RowHeightUnit != null)
            {
                builder.Append($"height: {CssConverter.Measurement(RowHeightUnit.Value, RowHeight)}; ");
            }

            Style = builder.ToString();
            StyleChanged = false;
            await InvokeAsync(StateHasChanged);
        }
        

        private object? GetFieldValue(string bindingFieldName)
        {
            if (!_cachedValues.ContainsKey(bindingFieldName))
            {
                _cachedValues[bindingFieldName] = Item?.GetType().GetProperty(bindingFieldName)?.GetValue(Item);
            }

            return _cachedValues[bindingFieldName];
        }

        private Dictionary<string, object?> _cachedValues = new();
    }
}
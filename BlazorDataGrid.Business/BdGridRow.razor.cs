using BlazorDataGrid.Business.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDataGrid.Business
{
    public partial class BdGridRow<TItem> : BdGridComponent
    {
        [CascadingParameter(Name = "ColumnDefinitions")]
        public IList<BdColumnDefinition> ColumnDefinitions { get; set; } = new List<BdColumnDefinition>();

        [Parameter]
        public ObservableDictionary<string, object?> FieldValues
        {
            get => _fieldValues;
            set
            {
                _fieldValues.CollectionChanged -= OnFieldValuesCollectionChanged;
                _fieldValues = value;
                _fieldValues.CollectionChanged += OnFieldValuesCollectionChanged;
            }
        }

        [Parameter]
        public TItem? Item { get; set; }
        
        [Parameter]
        public int Index { get; set; }

        [CascadingParameter(Name = "RowHeight")]
        public int RowHeight { get; set; }

        [CascadingParameter(Name = "RowHeightUnit")]
        public MeasurementUnit? RowHeightUnit { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> RowValueChanged { get; set; }

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


        protected override void OnInitialized()
        {
            base.OnInitialized();
            _itemTypeProperties = Item?.GetType().GetProperties();
            GetFieldValues();
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                _fieldValues.CollectionChanged += OnFieldValuesCollectionChanged;
            }
        }

        private void OnFieldValuesCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems == null) return;
            _fieldValues.CollectionChanged -= OnFieldValuesCollectionChanged;
            foreach (KeyValuePair<string, object?> kvp in e.NewItems)
            {
                _itemTypeProperties?.FirstOrDefault(p => p.Name == kvp.Key)?.SetValue(Item, kvp.Value);
            }

            RowValueChanged.InvokeAsync(new ChangeEventArgs{Value = new Tuple<int, TItem?>(Index, Item)});
            _fieldValues.CollectionChanged += OnFieldValuesCollectionChanged;
        }

        private void GetFieldValues()
        {
            foreach (var col in ColumnDefinitions)
            {
                GetFieldValue(col.BindingField);
            }
        }


        private void GetFieldValue(string bindingFieldName)
        {
            if (!_fieldValues.ContainsKey(bindingFieldName))
            {
                _fieldValues[bindingFieldName] = _itemTypeProperties?
                    .FirstOrDefault(p => p.Name == bindingFieldName)?.GetValue(Item);
            }
        }

        private ObservableDictionary<string, object?> _fieldValues = new();
        private PropertyInfo[]? _itemTypeProperties;
    }
}
﻿using BlazorDataGrid.Business.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDataGrid.Business.Components
{
    public partial class BdGridRow<TItem> : BdGridComponent
    {
        [CascadingParameter(Name = "ColumnDefinitions")]
        public IList<BdColumnDefinition> ColumnDefinitions { get; set; } = new List<BdColumnDefinition>();

        [Parameter]
        public ObservableDictionary<string, object?> FieldValues { get; set; } = new();

        [CascadingParameter(Name = "Grid")]
        public BdGridBase Grid { get; set; } = null!;

        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public TItem? Item { get; set; }

        [CascadingParameter(Name = "RowHeight")]
        public int RowHeight { get; set; }

        [CascadingParameter(Name = "RowHeightUnit")]
        public MeasurementUnit? RowHeightUnit { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> RowValueChanged { get; set; }
        
        [Parameter]
        public EventCallback<ChangeEventArgs> RowDeleted { get; set; }

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
            Grid.RowSourceChanged += OnRowSourceChanged;
            GetFieldValues();
        }

        private async void OnRowSourceChanged(object? sender, RowSourceChangedEventArgs e)
        {
            if (e.RowIndex == Index)
            {
                GetFieldValues();
                await InvokeAsync(StateHasChanged);
            }
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            GetFieldValues();
        }

        private async void OnFieldValuesCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems == null)
            {
                return;
            }

            FieldValues.CollectionChanged -= OnFieldValuesCollectionChanged;
            foreach (KeyValuePair<string, object?> kvp in e.NewItems)
            {
                _itemTypeProperties?.FirstOrDefault(p => p.Name == kvp.Key)?.SetValue(Item, kvp.Value);
            }

            await InvokeAsync(async () =>
            {
                await RowValueChanged.InvokeAsync(new ChangeEventArgs {Value = new Tuple<int, TItem?>(Index, Item)});
                FieldValues.CollectionChanged += OnFieldValuesCollectionChanged;
            });
        }

        private void GetFieldValues()
        {
            FieldValues.CollectionChanged -= OnFieldValuesCollectionChanged;
            FieldValues.Clear();
            foreach (var col in ColumnDefinitions)
            {
                GetFieldValue(col.BindingField);
            }

            FieldValues.CollectionChanged += OnFieldValuesCollectionChanged;
        }


        private void GetFieldValue(string bindingFieldName)
        {
            if (!FieldValues.ContainsKey(bindingFieldName))
            {
                FieldValues[bindingFieldName] = _itemTypeProperties?
                    .FirstOrDefault(p => p.Name == bindingFieldName)?.GetValue(Item);
            }
        }

        private PropertyInfo[]? _itemTypeProperties;

        private async Task OnDeleteButtonClicked()
        {
            await RowDeleted.InvokeAsync(new ChangeEventArgs{Value = Index});
        }
    }
}
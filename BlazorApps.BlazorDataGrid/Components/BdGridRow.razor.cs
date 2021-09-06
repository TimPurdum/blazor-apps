using BlazorApps.BlazorDataGrid.Utilities;
using BlazorApps.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;

namespace BlazorApps.BlazorDataGrid.Components
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
        public MeasurementUnit RowHeightUnit { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> RowValueChanged { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> RowDeleted { get; set; }

        public override async void BuildStyle(StringBuilder? builder = null)
        {
            if (!StyleChanged)
            {
                return;
            }

            builder ??= new StringBuilder();
            var height = CssConverter.Measurement(RowHeightUnit, RowHeight);
            builder.Append($"height: {height}; line-height: {height};");

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
            _cts.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;
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
                if (token.IsCancellationRequested) return;
                GetFieldValues();
                await RowValueChanged.InvokeAsync(new ChangeEventArgs {Value = new Tuple<int, TItem?>(Index, Item)});
                _cts.Cancel();
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

        private CancellationTokenSource _cts = new CancellationTokenSource();
    }
}
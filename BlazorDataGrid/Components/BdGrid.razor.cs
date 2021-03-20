using BlazorApps.BlazorDataGrid.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApps.BlazorDataGrid.Components
{
    public partial class BdGrid<TItem> where TItem : new()
    {
        public override event EventHandler<RowSourceChangedEventArgs>? RowSourceChanged;


        [Parameter]
        public IList<TItem> ItemsSource
        {
            get
            {
                lock (_itemLock)
                {
                    return _itemsSource;
                }
            }
            set
            {
                if (_preventRefresh)
                {
                    _preventRefresh = false;
                    return;
                };
                IList<TItem> tempSource;
                ClearItemPropertyHandlers();
                lock (_itemLock)
                {
                    tempSource = value;
                    _itemsSource = new List<TItem>();
                }

                Task.Run(async () =>
                {
                    await InvokeAsync(async () =>
                    {
                        StateHasChanged();
                        await Task.Run(async () =>
                        {
                            lock (_itemLock)
                            {
                                _itemsSource = tempSource;
                            }

                            await InvokeAsync( () =>
                            {
                                StateHasChanged();
                                AddItemPropertyHandlers();
                            });
                        });
                    });
                });
            }
        }


        [Parameter]
        public EventCallback<IList<TItem>> ItemsSourceChanged { get; set; }

        private async Task OnRowValueChanged(ChangeEventArgs e)
        {
            if (!(e.Value is Tuple<int, TItem?> args) || args.Item2 == null || args.Item1 < 0 ||
                args.Item1 > ItemsSource.Count - 1)
            {
                return;
            }

            ClearItemPropertyHandlers();

            lock (_itemLock)
            {
                ItemsSource[args.Item1] = args.Item2;
            }

            _preventRefresh = true;
            
            await InvokeAsync(async () =>
            {
                await ItemsSourceChanged.InvokeAsync(ItemsSource);
            });
        }


        private async Task OnHeaderWidthChanged()
        {
            await InvokeAsync(StateHasChanged);
        }


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
                            FieldType = SetFieldType(prop.PropertyType),
                            IsEditable = IsEditable
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
            ClearItemPropertyHandlers();
            AddItemPropertyHandlers();
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

        private void ClearItemPropertyHandlers()
        {
            lock (_itemLock)
            {
                foreach (var item in _itemsSource)
                {
                    if (item is INotifyPropertyChanged propItem)
                    {
                        propItem.PropertyChanged -= OnItemPropertyChanged;
                    }
                }
            }
        }

        private void AddItemPropertyHandlers()
        {
            lock (_itemLock)
            {
                foreach (var item in _itemsSource)
                {
                    if (item is INotifyPropertyChanged propItem)
                    {
                        propItem.PropertyChanged += OnItemPropertyChanged;
                    }
                }
            }
        }

        private async void OnItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            int index;
            TItem item;

            ClearItemPropertyHandlers();
            lock (_itemLock)
            {
                item = (TItem) sender!;
                index = ItemsSource.IndexOf(item);
            }

            await OnRowValueChanged(new ChangeEventArgs {Value = new Tuple<int, TItem?>(index, item)});
            RowSourceChanged?.Invoke(this, new RowSourceChangedEventArgs(index));
        }

        private async Task OnAddRowClicked()
        {
            ClearItemPropertyHandlers();
            lock (_itemLock)
            {
                ItemsSource.Add(new TItem());
            }

            await ItemsSourceChanged.InvokeAsync(ItemsSource);
            AddItemPropertyHandlers();
        }


        private async Task OnRowDeleted(ChangeEventArgs e)
        {
            ClearItemPropertyHandlers();
            lock (_itemLock)
            {
                ItemsSource.RemoveAt((int) e.Value!);
            }

            await ItemsSourceChanged.InvokeAsync(ItemsSource);
            AddItemPropertyHandlers();
        }

        private readonly object _itemLock = new();
        private IList<TItem> _itemsSource = new ObservableCollection<TItem>();
        private Virtualize<TItem> VirtualGrid { get; set; } = null!;
        private bool _preventRefresh;
    }

    public class BdGridBase : BdGridComponent
    {
        public virtual event EventHandler<RowSourceChangedEventArgs>? RowSourceChanged
        {
            add => throw new NotImplementedException();
            remove => throw new NotImplementedException();
        }

        [Parameter]
        public bool AutoGenerateColumns { get; set; } = true;

        [Parameter]
        public bool CanUserAddRows { get; set; }

        [Parameter]
        public bool CanUserDeleteRows { get; set; }

        [Parameter]
        public bool CanUserResizeColumns { get; set; }

        [Parameter]
        public IList<BdColumnDefinition> ColumnDefinitions { get; set; } = new List<BdColumnDefinition>();

        [Parameter]
        public int Height { get; set; }

        [Parameter]
        public MeasurementUnit? HeightUnit { get; set; } = MeasurementUnit.Pixel;

        [Parameter]
        public override bool? IsEditable { get; set; }

        [Parameter]
        public int RowHeight { get; set; } = 40;

        [Parameter]
        public MeasurementUnit RowHeightUnit { get; set; } = MeasurementUnit.Pixel;

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


        public override void BuildStyle(StringBuilder? builder = null)
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


    public class RowSourceChangedEventArgs : EventArgs
    {
        public RowSourceChangedEventArgs(int rowIndex)
        {
            RowIndex = rowIndex;
        }

        public int RowIndex { get; }
    }
}
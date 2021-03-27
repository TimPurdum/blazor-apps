using Microsoft.AspNetCore.Components;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApps.BlazorDataGrid.Components.Cells
{
    public class BdInputCell<T>: BdGridComponent
    {
        [Parameter]
        public BdColumnDefinition ColumnDefinition { get; set; } = null!;

        [Parameter]
        public T TypedValue
        {
            get => _typedValue;
            set
            {
                if (_typedValue == null || !_typedValue.Equals(value))
                {
                    _typedValue = value;
                    _valueChanged = true;
                }
            }
        }

        [Parameter]
        public virtual object? Value
        {
            get => TypedValue;
            set
            {
                if (value is T t)
                {
                    TypedValue = t;
                }
            }
        }

        [Parameter]
        public EventCallback<object> ValueChanged { get; set; }
        
        [CascadingParameter(Name = "Grid")]
        public BdGridBase Grid { get; set; } = null!;

        public override void BuildStyle(StringBuilder? builder = null)
        {
            ColumnDefinition.BuildStyle(builder);
            Style = ColumnDefinition.Style;
            IsEditable = (Grid.IsEditable ?? false) && (ColumnDefinition.IsEditable ?? false);
        }

        protected async Task FocusOut()
        {
            if (_valueChanged || Value != _originalValue)
            {
                _valueChanged = false;
                await ValueChanged.InvokeAsync(Value);
            }
        }
        
        protected void FocusIn()
        {
            _originalValue = Value;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            _valueChanged = false;
        }

        private T _typedValue = default!;
        private bool _valueChanged;
        private object? _originalValue;
    }
}
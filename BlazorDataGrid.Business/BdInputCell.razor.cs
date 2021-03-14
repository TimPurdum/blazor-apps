using Microsoft.AspNetCore.Components;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDataGrid.Business
{
    public partial class BdInputCell<T>
    {
        [Parameter]
        public BdColumnDefinition ColumnDefinition { get; set; } = null!;

        [Parameter]
        public object? Value
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
        public T TypedValue
        {
            get => _typedValue;
            set
            {
                _typedValue = value;
                ValueChanged.InvokeAsync(Value);
            }
        }

        [Parameter]
        public EventCallback<object> ValueChanged { get; set; }

        public override async Task BuildStyle(StringBuilder? builder = null)
        {
            await ColumnDefinition.BuildStyle(builder);
            Style = ColumnDefinition.Style;
        }


        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            InheritValues(ColumnDefinition);
        }

        private T _typedValue = default!;
    }
}
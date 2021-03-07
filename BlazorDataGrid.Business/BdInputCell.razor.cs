using Microsoft.AspNetCore.Components;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDataGrid.Business
{
    public partial class BdInputCell
    {
        [Parameter]
        public BdColumnDefinition ColumnDefinition { get; set; } = null!;

        [Parameter]
        public object? Value
        {
            get => _value;
            set => _value = value;
        }

        [Parameter]
        public EventCallback<object> ValueChanged { get; set; }

        public override async Task BuildStyle(StringBuilder? builder = null)
        {
            await ColumnDefinition.BuildStyle(builder);
            Style = ColumnDefinition.Style;
        }

        protected void TypedValueChanged(object? typedValue)
        {
            Value = typedValue;
            ValueChanged.InvokeAsync(Value);
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            InheritValues(ColumnDefinition);
        }

        private object? _value;
    }
}
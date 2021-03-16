﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDataGrid.Business.Components.Cells
{
    public partial class BdInputCell<T>
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

        public override async Task BuildStyle(StringBuilder? builder = null)
        {
            await ColumnDefinition.BuildStyle(builder);
            Style = ColumnDefinition.Style;
            IsEditable = (Grid.IsEditable ?? false) && (ColumnDefinition.IsEditable ?? false);
        }

        protected async Task FocusOut(FocusEventArgs obj)
        {
            if (_valueChanged)
            {
                _valueChanged = false;
                await ValueChanged.InvokeAsync(Value);
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            _valueChanged = false;
        }

        private T _typedValue = default!;
        private bool _valueChanged;
    }
}
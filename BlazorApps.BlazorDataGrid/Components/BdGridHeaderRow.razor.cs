using BlazorApps.BlazorDataGrid.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApps.BlazorDataGrid.Components
{
    public partial class BdGridHeaderRow : BdGridComponent
    {
        [CascadingParameter(Name = "ColumnDefinitions")]
        public IList<BdColumnDefinition> ColumnDefinitions { get; set; } = new List<BdColumnDefinition>();

        [CascadingParameter(Name = "Grid")]
        public BdGridBase Grid { get; set; } = null!;

        [Parameter]
        public EventCallback HeaderWidthChanged { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            _resizerStyle = new string[ColumnDefinitions.Count];
            for (var i = 0; i < _resizerStyle.Length; i++)
            {
                _resizerStyle[i] = "background-color: transparent";
            }
        }

        private string BuildColumnHeaderStyle(BdColumnDefinition col)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"width:{CssConverter.ColumnWidthMeasurement(col.WidthUnit, col.Width)};");

            return stringBuilder.ToString();
        }

        private void ResizerMouseDown(int columnIndex)
        {
            _resizerStyle[columnIndex] = "background-color: black; border: 1px solid yellow;";
        }

        private void ResizerMouseUp(int columnIndex)
        {
            _resizerStyle[columnIndex] = "background-color: transparent; border: none;";
        }

        private void ResizerDragStart(DragEventArgs e, int columnIndex)
        {
            _startX = e.ClientX;
            e.DataTransfer.EffectAllowed = "move";
            e.DataTransfer.DropEffect = "move";
        }

        private async Task ResizerDragEnd(DragEventArgs e, int columnIndex)
        {
            var newWidth = ColumnDefinitions[columnIndex].Width + (int) (e.ClientX - _startX);
            if (newWidth < 20)
            {
                newWidth = 20;
            }
            else if (newWidth > 1000)
            {
                newWidth = 1000;
            }

            ColumnDefinitions[columnIndex].Width = newWidth;

            _resizerStyle[columnIndex] = "background-color: transparent; border: none;";
            e.DataTransfer.EffectAllowed = "";
            await HeaderWidthChanged.InvokeAsync();
        }

        private string[] _resizerStyle = new string[0];

        private double _startX;
    }
}
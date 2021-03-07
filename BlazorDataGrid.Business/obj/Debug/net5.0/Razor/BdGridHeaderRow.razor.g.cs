#pragma checksum "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridHeaderRow.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fd025b3a6f7b39c305131a5331f9c50dfd21a7f"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorDataGrid.Business
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridHeaderRow.razor"
using System.Text;

#line default
#line hidden
#nullable disable
    public partial class BdGridHeaderRow : BlazorDataGrid.Business.Components.BdGridComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "bd-grid-header-row");
            __builder.AddAttribute(2, "b-hjgl0bpt76");
#nullable restore
#line 5 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridHeaderRow.razor"
     foreach (var col in ColumnDefinitions)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "bd-grid-header");
            __builder.AddAttribute(5, "style", 
#nullable restore
#line 7 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridHeaderRow.razor"
                                            BuildColumnHeaderStyle(col)

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(6, "b-hjgl0bpt76");
            __builder.AddContent(7, 
#nullable restore
#line 7 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridHeaderRow.razor"
                                                                          col.Header

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 8 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridHeaderRow.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 11 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridHeaderRow.razor"
       

    [CascadingParameter(Name = "ColumnDefinitions")]
    public IList<BdColumnDefinition> ColumnDefinitions { get; set; } = new List<BdColumnDefinition>();

    private string BuildColumnHeaderStyle(BdColumnDefinition col)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"width:{CssConverter.ColumnWidthMeasurement(col.WidthUnit, col.Width)}");

        return stringBuilder.ToString();
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
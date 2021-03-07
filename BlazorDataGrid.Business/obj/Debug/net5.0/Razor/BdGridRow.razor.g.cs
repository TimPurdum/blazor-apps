#pragma checksum "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0ee3d5601eb146347ff24102df3796590894421"
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
#line 2 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
    public partial class BdGridRow<TItem> : BlazorDataGrid.Business.Components.BdGridComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "bd-grid-row");
            __builder.AddAttribute(2, "style", 
#nullable restore
#line 5 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                 Style

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(3, "b-an0mv66476");
            __Blazor.BlazorDataGrid.Business.BdGridRow.TypeInference.CreateVirtualize_0(__builder, 4, 5, 
#nullable restore
#line 6 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                        ColumnDefinitions

#line default
#line hidden
#nullable disable
            , 6, (columnDefinition) => (__builder2) => {
#nullable restore
#line 7 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
          
            if (Item == null) return;
            var fieldValue = GetFieldValue(columnDefinition.BindingField);
            switch (columnDefinition.FieldType)
            {
                case null:
                case FieldType.Text:

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<BlazorDataGrid.Business.BdTextCell>(7);
                __builder2.AddAttribute(8, "Parent", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.Components.BdGridComponent>(
#nullable restore
#line 14 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                          this

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(9, "ColumnDefinition", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.BdColumnDefinition>(
#nullable restore
#line 14 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                                                             columnDefinition

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(10, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 14 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                              fieldValue

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(11, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Object>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Object>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => fieldValue = __value, fieldValue))));
                __builder2.CloseComponent();
#nullable restore
#line 15 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                    break;
                case FieldType.Checkbox:

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<BlazorDataGrid.Business.BdCheckboxCell>(12);
                __builder2.AddAttribute(13, "Parent", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.Components.BdGridComponent>(
#nullable restore
#line 17 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                              this

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(14, "ColumnDefinition", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.BdColumnDefinition>(
#nullable restore
#line 17 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                                                                 columnDefinition

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(15, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 17 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                                  fieldValue

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(16, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Object>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Object>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => fieldValue = __value, fieldValue))));
                __builder2.CloseComponent();
#nullable restore
#line 18 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                    break;
                case FieldType.IntNumeric:

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<BlazorDataGrid.Business.BdIntNumericCell>(17);
                __builder2.AddAttribute(18, "Parent", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.Components.BdGridComponent>(
#nullable restore
#line 20 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                this

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(19, "ColumnDefinition", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.BdColumnDefinition>(
#nullable restore
#line 20 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                                                                   columnDefinition

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 20 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                                    fieldValue

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Object>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Object>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => fieldValue = __value, fieldValue))));
                __builder2.CloseComponent();
#nullable restore
#line 21 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                    break;
                case FieldType.DoubleNumeric:

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<BlazorDataGrid.Business.BdDoubleNumericCell>(22);
                __builder2.AddAttribute(23, "Parent", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.Components.BdGridComponent>(
#nullable restore
#line 23 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                   this

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(24, "ColumnDefinition", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.BdColumnDefinition>(
#nullable restore
#line 23 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                                                                      columnDefinition

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(25, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 23 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                                       fieldValue

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(26, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Object>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Object>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => fieldValue = __value, fieldValue))));
                __builder2.CloseComponent();
#nullable restore
#line 24 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                    break;
                case FieldType.Date:

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<BlazorDataGrid.Business.BdDateCell>(27);
                __builder2.AddAttribute(28, "Parent", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.Components.BdGridComponent>(
#nullable restore
#line 26 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                          this

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(29, "ColumnDefinition", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.BdColumnDefinition>(
#nullable restore
#line 26 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                                                             columnDefinition

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(30, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 26 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                              fieldValue

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(31, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Object>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Object>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => fieldValue = __value, fieldValue))));
                __builder2.CloseComponent();
#nullable restore
#line 27 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                    break;
                case FieldType.Time:

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<BlazorDataGrid.Business.BdTimeCell>(32);
                __builder2.AddAttribute(33, "Parent", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.Components.BdGridComponent>(
#nullable restore
#line 29 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                          this

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(34, "ColumnDefinition", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.BdColumnDefinition>(
#nullable restore
#line 29 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                                                             columnDefinition

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(35, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 29 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                              fieldValue

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(36, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Object>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Object>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => fieldValue = __value, fieldValue))));
                __builder2.CloseComponent();
#nullable restore
#line 30 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                    break;
                case FieldType.DateTimeLocal:

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<BlazorDataGrid.Business.BdDateTimeLocalCell>(37);
                __builder2.AddAttribute(38, "Parent", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.Components.BdGridComponent>(
#nullable restore
#line 32 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                   this

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(39, "ColumnDefinition", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorDataGrid.Business.BdColumnDefinition>(
#nullable restore
#line 32 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                                                                      columnDefinition

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(40, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 32 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                                                                       fieldValue

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(41, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Object>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Object>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => fieldValue = __value, fieldValue))));
                __builder2.CloseComponent();
#nullable restore
#line 33 "C:\git\BlazorDataGrid\BlazorDataGrid.Business\BdGridRow.razor"
                    break;
            }
        

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.BlazorDataGrid.Business.BdGridRow
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateVirtualize_0<TItem>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.Generic.ICollection<TItem> __arg0, int __seq1, global::Microsoft.AspNetCore.Components.RenderFragment<TItem> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize<TItem>>(seq);
        __builder.AddAttribute(__seq0, "Items", __arg0);
        __builder.AddAttribute(__seq1, "ChildContent", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
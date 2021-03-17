using BlazorDataGrid.Business.Utilities;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDataGrid.Business.Components
{
    public abstract class BdGridComponent : ComponentBase
    {
        [Parameter]
        public Color? BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                if (value != _backgroundColor)
                {
                    _backgroundColor = value;
                    StyleChanged = true;
                }
            }
        }

        [Parameter]
        public double? FontEmSize
        {
            get => _fontEmSize;
            set
            {
                if (!Equals(value, _fontEmSize))
                {
                    _fontEmSize = value;
                    StyleChanged = true;
                }
            }
        }

        [Parameter]
        public string? FontFamily
        {
            get => _fontFamily;
            set
            {
                if (value != _fontFamily)
                {
                    _fontFamily = value;
                    StyleChanged = true;
                }
            }
        }

        [Parameter]
        public FontStyle? FontStyle
        {
            get => _fontStyle;
            set
            {
                if (value != _fontStyle)
                {
                    _fontStyle = value;
                    StyleChanged = true;
                }
            }
        }

        [Parameter]
        public FontWeight? FontWeight
        {
            get => _fontWeight;
            set
            {
                if (value != _fontWeight)
                {
                    _fontWeight = value;
                    StyleChanged = true;
                }
            }
        }

        [Parameter]
        public Color? ForegroundColor
        {
            get => _foregroundColor;
            set
            {
                if (value != _foregroundColor)
                {
                    _foregroundColor = value;
                    StyleChanged = true;
                }
            }
        }

        [Parameter]
        public HorizontalAlignment? HorizontalContentAlignment
        {
            get => _horizontalContentAlignment;
            set
            {
                if (value != _horizontalContentAlignment)
                {
                    _horizontalContentAlignment = value;
                    StyleChanged = true;
                }
            }
        }
        
        public virtual bool? IsEditable { get; set; }
        

        [Parameter]
        public string Style { get; set; } = string.Empty;

        public bool StyleChanged { get; set; } = true;

        [Parameter]
        public VerticalAlignment? VerticalContentAlignment
        {
            get => _verticalContentAlignment;
            set
            {
                if (value != _verticalContentAlignment)
                {
                    _verticalContentAlignment = value;
                    StyleChanged = true;
                }
            }
        }


        public virtual void BuildStyle(StringBuilder? builder = null)
        {
            if (!StyleChanged)
            {
                return;
            }

            builder ??= new StringBuilder();

            if (HorizontalContentAlignment.HasValue)
            {
                builder.Append($"text-align:{HorizontalContentAlignment}; ");
            }

            if (VerticalContentAlignment.HasValue)
            {
                builder.Append($"vertical-align:{VerticalContentAlignment}; ");
            }

            if (FontEmSize.HasValue)
            {
                builder.Append($"font-size:{FontEmSize}em; ");
            }

            if (FontStyle.HasValue)
            {
                builder.Append($"font-style:{FontStyle}; ");
            }

            if (FontWeight.HasValue)
            {
                builder.Append($"font-weight:{FontWeight}; ");
            }

            if (ForegroundColor.HasValue)
            {
                builder.Append($"color:{ColorTranslator.ToHtml(ForegroundColor.Value)}; ");
            }

            if (BackgroundColor.HasValue)
            {
                builder.Append($"background-color:{ColorTranslator.ToHtml(BackgroundColor.Value)}; ");
            }

            Style = builder.ToString();
            StyleChanged = false;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            BuildStyle();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

        private Color? _backgroundColor;
        private double? _fontEmSize;
        private string? _fontFamily;
        private FontStyle? _fontStyle;
        private FontWeight? _fontWeight;
        private Color? _foregroundColor;
        private HorizontalAlignment? _horizontalContentAlignment;
        private VerticalAlignment? _verticalContentAlignment;
    }
}
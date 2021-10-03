using BlazorApps.BlazorCharts.Model;
using BlazorApps.BlazorCharts.Model.ChartTypes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Drawing;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApps.BlazorCharts
{
    public partial class BlazorChart: IAsyncDisposable
    {
        [Inject]
        private IJSRuntime _jsRuntime { get; set; } = null!;

        [Parameter]
        public ChartConfiguration? Configuration { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            ConfigureJsRuntime();
            _moduleTask = new Lazy<Task<IJSObjectReference>>(() => 
                _jsRuntime.InvokeAsync<IJSObjectReference>(
                    "import", "./_content/CedarRiverTech.BlazorApps.BlazorCharts/BlazorChartJsInterop.js")
                    .AsTask());
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            Console.WriteLine("Json:");
            var json = JsonSerializer.Serialize(Configuration);
            Console.WriteLine(json);
            var module = await _moduleTask.Value;
            await module.InvokeAsync<string>("InitializeChart", Configuration);
        }


        private Lazy<Task<IJSObjectReference>>? _moduleTask;

        public async ValueTask DisposeAsync()
        {
            if (_moduleTask != null && _moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }


        private void ConfigureJsRuntime()
        {
            if (_defaultsSet) return;
            var prop = typeof(JSRuntime).GetProperty("JsonSerializerOptions", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            var options = (JsonSerializerOptions)Convert.ChangeType(
                    prop.GetValue(_jsRuntime, null), typeof(JsonSerializerOptions));
            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            _defaultsSet = true;
        }


        private bool _defaultsSet;
    }
}
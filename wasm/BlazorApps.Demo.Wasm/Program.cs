using BlazorApps.BlazorDataGrid.Demo;
using BlazorApps.BlazorMusicKeyboard;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System.Linq;
using System.Text.Json;

namespace BlazorApps.Demo.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            var jsRuntime = builder.Services.BuildServiceProvider().GetRequiredService<IJSRuntime>();
            var module = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "/componentFinder.js");
            var json = await module.InvokeAsync<JsonElement>("getBlazorComponents");
            foreach(var id in json.EnumerateArray())
            {
                switch (id.ToString())
                {
                    case "blazor-data-grid":
                        builder.RootComponents.Add<BdGridDemo>("#blazor-data-grid");
                        break;
                    case "blazor-music-keyboard":
                        builder.RootComponents.Add<MusicKeyboardDemo>("#blazor-music-keyboard");
                        break;       
                }
            }

            if (!builder.RootComponents.Any()) return;
            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(new Uri(builder.HostEnvironment.BaseAddress).Host)});

            await builder.Build().RunAsync();
        }
    }
}
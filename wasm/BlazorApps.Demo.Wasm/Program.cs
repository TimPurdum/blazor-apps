using BlazorApps.BlazorDataGrid.Demo;
using BlazorApps.BlazorMusicKeyboard;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApps.Demo.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents
                .Add<BdGridDemo>("#blazor-data-grid");
            builder.RootComponents
                .Add<MusicKeyboardDemo>("#blazor-music-keyboard");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(new Uri(builder.HostEnvironment.BaseAddress).Host)});

            await builder.Build().RunAsync();
        }
    }
}
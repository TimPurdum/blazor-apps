using BlazorApps.BlazorDataGrid.Demo;
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
                .Add<Root>("#blazor-apps");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(new Uri(builder.HostEnvironment.BaseAddress).Host)});

            await builder.Build().RunAsync();
        }
    }
}
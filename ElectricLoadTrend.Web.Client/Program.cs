using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ElectricLoadTrend.Web.Client.Services;

namespace ElectricLoadTrend.Web.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.Services.AddHttpClient("WebAPI", client => client.BaseAddress= new Uri(builder.HostEnvironment.BaseAddress));
        builder.Services.AddScoped(hc=> hc.GetRequiredService<IHttpClientFactory>().CreateClient("WebAPI"));
        
        builder.Services.AddScoped<ITrendDataService, TrendDataService>();
        await builder.Build().RunAsync();
        
    }
}

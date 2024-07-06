using ElectricLoadTrend.Web.Client.Pages;
using ElectricLoadTrend.Web.Components;
using ElectricLoadTrend.Services;
using ElectricLoadTrend.Data;
using ElectricLoadTrend.Web.Client.Services;
namespace ElectricLoadTrend.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();
    
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<GenerationDataContext>();
        builder.Services.AddScoped<IGenerationDataService, GenerationDataService>();

        builder.Services.AddHttpClient("WebAPI", client => client.BaseAddress= new Uri("http://localhost:5062"));
        builder.Services.AddScoped(hc=> hc.GetRequiredService<IHttpClientFactory>().CreateClient("WebAPI"));
        
        builder.Services.AddScoped<ITrendDataService, TrendDataService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();
        #pragma warning disable  CS0234 
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.Run();
    }
}

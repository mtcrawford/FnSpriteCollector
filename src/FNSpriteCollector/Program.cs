using FNSpriteCollector;
using FNSpriteCollector.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<IndexedDbService>();
builder.Services.AddScoped<SpriteDbService>();

//builder.Services.AddScoped<LocalStorageService>();
//builder.Services.AddScoped<SpriteService>();
builder.Services.AddScoped<SpriteSeederDTO>();

builder.Services.AddMudServices();

var host = builder.Build();


await host.RunAsync();
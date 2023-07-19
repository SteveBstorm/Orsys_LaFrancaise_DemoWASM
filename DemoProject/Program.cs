using DemoProject;
using DemoProject.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Inscription des services
//builder.Services.AddSingleton<ArticleService>();
builder.Services.AddScoped<ArticleService_API>();
//builder.Services.AddScoped<ArticleService>(); => Une instance par appel du client
//builder.Services.AddTransient<ArticleService>(); => Une instance par appel au service

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

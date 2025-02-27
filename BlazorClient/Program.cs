using BlazorClient;
using BlazorClient.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://webbapi-app-20250227044025.victoriouswave-6ada8f32.swedencentral.azurecontainerapps.io") });

builder.Services.AddScoped<BasicModelService>();

await builder.Build().RunAsync();

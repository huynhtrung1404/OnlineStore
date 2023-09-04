using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OnlineStore.Web;
using OnlineStore.Web.Services;
using OnlineStore.Web.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7217") });
builder.Services.AddScoped(typeof(IApiService<>), typeof(ApiService<>));
builder.Services.AddHttpClient();

await builder.Build().RunAsync();

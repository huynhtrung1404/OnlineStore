using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OnlineStore.Web;
using OnlineStore.Web.Services;
using OnlineStore.Web.Services.Interfaces;
using OnlineStore.Web.Commons;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddHttpClient(Constant.WebApiName, conf =>
{
    conf.BaseAddress = new Uri("https://localhost:6002");
});

await builder.Build().RunAsync();

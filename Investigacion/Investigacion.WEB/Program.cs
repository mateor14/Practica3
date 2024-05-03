using CurrieTechnologies.Razor.SweetAlert2;
using Investigacion.WEB;
using Investigacion.WEB.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7043/") });
builder.Services.AddSweetAlert2();
builder.Services.AddScoped<IRepository, Repository>();

await builder.Build().RunAsync();

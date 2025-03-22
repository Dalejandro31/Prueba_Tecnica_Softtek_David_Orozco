using CRUD.Frontend;
using CRUD.Frontend.Interfaces;
using CRUD.Frontend.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var url = "https://localhost:7203";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(url) });

builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<ILibroService, LibroService>();

await builder.Build().RunAsync();

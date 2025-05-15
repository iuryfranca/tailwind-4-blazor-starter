using Flowbite.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using tailwind_4_blazor_starter;
using tailwind_4_blazor_starter.Services;
using Microsoft.EntityFrameworkCore;
using LearningBlazor.Context;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IFlowbiteService, FlowbiteService>();
builder.Services.AddScoped<SideMenuService>();

string mySqlConnectionStr = builder.Configuration.GetConnectionString("Server=localhost; Port=3306; Database=bd_concursos;Uid=root;Pwd=root;Connection Timeout=300");
builder.Services.AddDbContextPool<ContextDB>(options =>
    options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr))
);

await builder.Build().RunAsync();

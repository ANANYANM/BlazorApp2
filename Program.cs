using BlazorApp2;
using BlazorApp2.Components;
using BlazorApp2.Shared.Models;
using BlazorApp2.Models;
using BlazorApp2.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<TicketService>();
builder.Services.AddSingleton<GlobalVariables>();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ICustomAuthenticationService, CustomAuthenticationService>();
builder.Services.AddAuthorization();
builder.Services.AddScoped<AuthenticationService>();
// Add the database context
//builder.Services.AddScoped(http => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!) });
//builder.Services.AddDbContext<BlazorApp2.Models.TicketContext>(option =>
               // option.UseSqlServer(builder.Configuration.GetConnectionString("TicketingSystem")));//
builder.Services.AddDbContext<BlazorApp2.Models.TicketContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("TicketingSystem")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler( "/Error");
    app.UseHsts();
    app.UseMigrationsEndPoint();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

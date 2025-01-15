using BlazorAppCarsCrud.Components;
using BlazorAppCarsCrud.Data;
using BlazorAppCarsCrud.Hubs;
using BlazorAppCarsCrud.Services;
using Blazored.LocalStorage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Leer configuraci�n de variables de ambiente
builder.Configuration.AddEnvironmentVariables();

// Configurar el servicio de base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? builder.Configuration["CloudConnection"];
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<MessageService>();

// Add SignalR service
builder.Services.AddSignalR();  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // Aseg�rate de que UseRouting est� antes de MapRazorComponents y SignalR

//app.UseAuthentication();
//app.UseAuthorization();

// A�adir protecci�n contra falsificaci�n
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
// Configurar el endpoint del Hub
app.MapHub<ChatHub>("/chathub");
app.Run();
    
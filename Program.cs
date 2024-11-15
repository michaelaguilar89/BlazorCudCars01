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
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=cars.db"));
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

app.UseRouting(); // Asegúrate de que UseRouting esté antes de MapRazorComponents y SignalR

//app.UseAuthentication();
//app.UseAuthorization();

// Añadir protección contra falsificación
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
// Configurar el endpoint del Hub
app.MapHub<ChatHub>("/chathub");
app.Run();
    
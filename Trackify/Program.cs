using Trackify;
using Trackify.API;
using Trackify.Hubs;
using Trackify.Interfaces;
using Trackify.Repositories;
using Trackify.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();

builder.Services.AddScoped<DeliveryService>();

builder.Services.AddScoped<ILocationNotifier, SignalLocationNotifier>();

builder.Services.AddScoped<OrderService>();
builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();

builder.Services.AddScoped<CourierService>();
builder.Services.AddSingleton<ICourierRepository, InMemoryCourierRepository>();

builder.Services.AddScoped<LocationService>();
builder.Services.AddSingleton<ILocationRepository, InMemoryLocationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllers();
app.MapHub<CourierHub>("/courierHub");

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
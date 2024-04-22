using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GameRazorPage_MVC_22_04_2024.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<GameRazorPage_MVC_22_04_2024Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameRazorPage_MVC_22_04_2024Context") ?? throw new InvalidOperationException("Connection string 'GameRazorPage_MVC_22_04_2024Context' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

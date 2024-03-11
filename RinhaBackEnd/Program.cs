using Microsoft.EntityFrameworkCore;
using RinhaBackEnd.Infra.Context;

var builder = WebApplication.CreateBuilder(args);

var config = typeof(IConfiguration);

var dbHostname = Environment.GetEnvironmentVariable("DB_HOSTNAME") ?? "localhost";

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<DbContextCfg>(options =>
{
    options.UseNpgsql(connectionString?.Replace("{server}", dbHostname));
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
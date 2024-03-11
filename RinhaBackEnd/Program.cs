using Microsoft.EntityFrameworkCore;
using RinhaBackEnd.Infra.Context;

var builder = WebApplication.CreateBuilder(args);

var config = typeof(IConfiguration);

builder.Services.AddDbContext<DbContextCfg>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});


builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
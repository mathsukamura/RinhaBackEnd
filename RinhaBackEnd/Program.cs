using Microsoft.EntityFrameworkCore;
using RinhaBackEnd;
using RinhaBackEnd.Infra.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContextCfg>(options =>
{
    options.UseNpgsql(ConfigConnectionString.Config(builder));
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
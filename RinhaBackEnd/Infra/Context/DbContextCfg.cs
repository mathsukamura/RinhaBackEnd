using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using RinhaBackEnd.Models.Client;

namespace RinhaBackEnd.Infra.Context;

public class DbContextCfg : DbContext
{
    public DbContextCfg(DbContextOptions<DbContextCfg> options) : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                if (property.GetDefaultColumnBaseName() != property.GetColumnBaseName()) continue;
                var columnname = property.GetDefaultColumnBaseName().ToSnakeCase();
                property.SetColumnName(columnname);
            }
        }
        
        modelBuilder.Entity<Cliente>().HasData(
            new Cliente(1,  100_000, 0 ),
            new Cliente(2,  80_000,  0),
            new Cliente(3,  1_000_000,  0 ),
            new Cliente(4,  10_000_000,  0 ),
            new Cliente(5, 500_000,  0 )
        );
    }
}

public static class StringExtensions
{
    public static string ToSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input)) { return input; }

        var startUnderscores = Regex.Match(input, @"^_+");
        return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
    }
}
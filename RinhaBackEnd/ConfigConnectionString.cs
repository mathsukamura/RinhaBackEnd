namespace RinhaBackEnd;

public static class ConfigConnectionString
{
    public static string? Config(WebApplicationBuilder? builder)
    {
        var dbHostname = Environment.GetEnvironmentVariable("DB_HOSTNAME") ?? "localhost";

        var connectionString = builder?.Configuration.GetConnectionString("Default");

        var concat = connectionString?.Replace("{server}", dbHostname);

        return concat;
    }
}
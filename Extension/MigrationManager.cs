using RepositoryPattern.Data;

namespace RepositoryPattern.Extension
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using(var scope = host.Services.CreateScope())
            using(var appContext = scope.ServiceProvider.GetRequiredService<SQLiteContext>())
            {
                try
                {
                    appContext.Database.EnsureCreated();
                }
                catch (System.Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error");
                }
            }
            return host;
        }
    }
}
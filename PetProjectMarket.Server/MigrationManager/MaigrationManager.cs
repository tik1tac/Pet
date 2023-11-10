using Microsoft.EntityFrameworkCore;

using Serilog;

public static class MigrationManager
{
    public static async Task<WebApplication> MigrateDatabase(this WebApplication webapp)
    {
        using (var scope = webapp.Services.CreateScope())
        {
            using (var app = scope.ServiceProvider.GetRequiredService<AplicationContext>())
            {
                try
                {
                    await app.Database.MigrateAsync();
                }
                catch (Exception)
                {
                    Log.Error("Failed connect to database");
                }
            }
            return webapp;
        }
    }
}
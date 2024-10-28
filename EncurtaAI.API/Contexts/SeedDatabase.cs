using Microsoft.EntityFrameworkCore;

namespace EncurtaAI.API.Contexts;

public static class SeedDatabase
{
    public static async Task SeedDatabaseAsync(this WebApplication app)
    {
        var services = app.Services.CreateScope().ServiceProvider;

        var context = services.GetRequiredService<DataContext>();

        var pendingMigrations = await context.Database.GetPendingMigrationsAsync();

        if (pendingMigrations.Any())
        {
            await context.Database.MigrateAsync();
        }
    }
}

using API.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.data.config
{
    public static class SeedConfig
    {
        public static async void ConfigureAndSeedDb(StoreContext context, ILoggerFactory loggerFactory)
        {
            await context.Database.MigrateAsync();
            await StoreContextSeed.SeedAsync(context, loggerFactory);
        }
    }
}

using DBFirst.Sample.Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Alten.HotelChallenge.SQLServer.Extensions
{
    public static class SqlExtension
    {
        public static IServiceCollection ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AltenContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlConnectionString")));

            return services;
        }

        public static IServiceCollection AddSqlServerHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(
                    p => configuration.GetConnectionString("SqlConnectionString"),
                    "SELECT 1;",
                    configuration["DatabaseName"],
                    HealthStatus.Unhealthy,
                    new[] { "db", "sql", "sqlserver", "ready" },
                    TimeSpan.FromSeconds(1));

            return services;
        }
    }
}

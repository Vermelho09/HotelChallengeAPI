using Alten.HotelChallenge.Application.Repositories;
using Alten.HotelChallenge.SQLServer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Alten.HotelChallenge.SQLServer.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            return services;
        }
    }
}

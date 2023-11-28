using Alten.HotelChallenge.Application.UseCases.CancelReservation;
using Alten.HotelChallenge.Application.UseCases.GetRoomAvailability;
using Alten.HotelChallenge.Application.UseCases.ModifyReservation;
using Alten.HotelChallenge.Application.UseCases.SetRoomReservation;
using Microsoft.Extensions.DependencyInjection;

namespace Alten.HotelChallenge.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGetRoomAvailability), typeof(GetRoomAvailability));
            services.AddScoped(typeof(ISetRoomReservation), typeof(SetRoomReservation));
            services.AddScoped(typeof(ICancelReservation), typeof(CancelReservation));
            services.AddScoped(typeof(IModifyReservation), typeof(ModifyReservation));

            return services;
        }
    }
}

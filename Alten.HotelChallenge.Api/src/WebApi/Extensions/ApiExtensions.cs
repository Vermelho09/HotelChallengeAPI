using Alten.HotelChallenge.Application.UseCases.CancelReservation;
using Alten.HotelChallenge.Application.UseCases.GetRoomAvailability;
using Alten.HotelChallenge.Application.UseCases.ModifyReservation;
using Alten.HotelChallenge.Application.UseCases.SetRoomReservation;
using Alten.HotelChallenge.WebApi.Validations;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace Alten.HotelChallenge.WebApi.Extensions
{
    public static class ApiExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetRoomAvailability).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(SetRoomReservation).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ModifyReservation).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CancelReservation).GetTypeInfo().Assembly);
            services.AddScoped<IMediator, Mediator>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<AbstractValidator<GetRoomAvailabilityInput>, AvailabilityValidator>();
            services.AddScoped<AbstractValidator<SetRoomReservationInput>, ReservationValidator>();

            return services;
        }
    }
}

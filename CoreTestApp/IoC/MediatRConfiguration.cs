using System.Reflection;
using CoreTestApp.Commands.Broadcast.Create;
using CoreTestApp.Queries.Broadcast.Get;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CoreTestApp.API.IoC
{
    public static class MediatRConfiguration
    {
        public static void ConfigureMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetBroadcastQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateBroadcastCommandHandler).GetTypeInfo().Assembly);
        }
    }
}

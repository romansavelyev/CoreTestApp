using System;
using CoreTestApp.Persistance.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;

namespace CoreTestApp.API.IoC
{
    public static class ODataConfiguration
    {
        public static void ConfigureODataServices(this IServiceCollection services)
        {
            services.AddOData();
        }

        internal static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Broadcast>("Broadcasts");
            builder.EntitySet<BroadcastType>("BroadcastTypes");
            return builder.GetEdmModel();
        }
    }
}

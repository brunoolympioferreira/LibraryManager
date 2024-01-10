using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infraestructure;
public static class InfraestructureModule
{
    public static void AddInfraestructure(this IServiceCollection services)
    {
    }

    private static IServiceCollection AddDb(this IServiceCollection services, string connectionString)
    {
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services;
    }
}

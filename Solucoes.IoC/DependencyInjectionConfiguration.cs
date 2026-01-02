using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solucoes.Infrastructure.Data.SolucoesDB;

namespace Solucoes.IoC;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        

        services.AddIdentity
    }
}

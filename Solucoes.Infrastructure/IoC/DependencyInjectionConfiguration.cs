using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Solucoes.Infrastructure.Data;
using Solucoes.Application.Interfaces.Identity;
using Solucoes.Infrastructure.Data.Identity.Entities;
using Solucoes.Application.Interfaces.Email;
using Solucoes.Infrastructure.Email.Services;
using Solucoes.Infrastructure.Data.Identity.Services;
using Solucoes.Domain.Repositories;
using Solucoes.Infrastructure.Data.Repositories;
using Solucoes.Application.Interfaces.Services;
using Solucoes.Application.Services;

namespace Solucoes.Infrastructure.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Contexts
            services.AddDbContext<SolucoesDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SolucoesDB"));
            });

            // ASP.NET Identity
            services.AddIdentity<Usuario, IdentityRole<int>>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
                .AddRoles<IdentityRole<int>>()
                .AddDefaultTokenProviders()
                .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<Usuario, IdentityRole<int>>>()
                .AddEntityFrameworkStores<SolucoesDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/auth/login";
                options.LogoutPath = "/auth/logout";
                options.ReturnUrlParameter = "returnUrl";

                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.SlidingExpiration = true;

                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.IsEssential = true;
            });

            // Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IProjetoService, ProjetoService>();

            // Repositories
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
        }
    }
}

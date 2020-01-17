using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Notificacoes;
using BolaoShow.Bussiness.Services;
using BolaoShow.Data.Context;
using BolaoShow.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BolaoShow.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Contexto>();
            services.AddScoped<IApostaRepository, ApostaRepository>();
            services.AddScoped<ISorteioRepository, SorteioRepository>();

            services.AddScoped<ISorteioService, SorteioService>();

            services.AddScoped<INotificador, Notificador>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUser, AspNetUser>();

            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}

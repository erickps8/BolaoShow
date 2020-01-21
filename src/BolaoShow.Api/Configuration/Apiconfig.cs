using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoShow.Api.Configuration
{
    public static class Apiconfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.AddMvc();
            
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());


                //options.AddPolicy("Production",
                //    builder =>
                //        builder
                //            .WithMethods("GET")
                //            .WithOrigins("http://desenvolvedor.io")
                //            .SetIsOriginAllowedToAllowWildcardSubdomains()
                //            //.WithHeaders(HeaderNames.ContentType, "x-custom-header")
                //            .AllowAnyHeader());
            });

            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            //app.UseMvc();

            return app;
        }
    }
}

namespace BolaoShow.Api.Configuration
{
    public static class SwaggerConfig
    {
    //    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    //    {
    //        services.AddSwaggerGen(c =>
    //        {
    //            //c.OperationFilter<SwaggerDefaultValues>();

    //            var security = new OpenApiSecurityRequirement()
    //            {
    //                {new OpenApiSecurityScheme{Reference = new OpenApiReference{
                    
    //                    Type = ReferenceType.SecurityScheme,
    //                    Id = "Bearer"
    //                }, 
    //                Scheme = "oauth2",
    //                Name = "Bearer",
    //                In = ParameterLocation.Header
    //                }, new List<string> { }}
    //            };

    //            c.AddSecurityDefinition("Bearer" ,new OpenApiSecurityScheme
    //            {
    //                Description = "Insira o token JWT desta maneira: Bearer {seu token}",
    //                Name = "Authorization",
    //                In = ParameterLocation.Header,
    //                Type = SecuritySchemeType.ApiKey
    //            });

    //            c.AddSecurityRequirement(security);
    //        });

    //        return services;
    //    }

    //    public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
    //    {
    //        //app.UseMiddleware<SwaggerAuthorizedMiddleware>();
    //        app.UseSwagger();
    //        app.UseSwaggerUI(
    //            options =>
    //            {
    //                foreach (var description in provider.ApiVersionDescriptions)
    //                {
    //                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    //                }
    //            });
    //        return app;
    //    }
    //}

    //public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    //{
    //    readonly IApiVersionDescriptionProvider provider;

    //    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

    //    public void Configure(SwaggerGenOptions options)
    //    {
    //        foreach (var description in provider.ApiVersionDescriptions)
    //        {
    //            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
    //        }
    //    }

    //    static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    //    {
    //        var info = new OpenApiInfo()
    //        {
    //            Title = "API - desenvolvedor.io",
    //            Version = description.ApiVersion.ToString(),
    //            Description = "Esta API faz parte do curso REST com ASP.NET Core WebAPI.",
    //            Contact = new OpenApiContact() { Name = "Erick Pinheiro", Email = "erickps8@hotmail.com" }
    //            //TermsOfService = "https://opensource.org/licenses/MIT",
    //            //License = new License() { Name = "MIT", Url = "https://opensource.org/licenses/MIT" }
    //        };

    //        if (description.IsDeprecated)
    //        {
    //            info.Description += " Esta versão está obsoleta!";
    //        }

    //        return info;
    //    }
    //}

    ////public class SwaggerDefaultValues : IOperationFilter
    ////{
    ////    public void Apply(Operation operation, OperationFilterContext context)
    ////    {
    ////        var apiDescription = context.ApiDescription;

    ////        operation.Deprecated = apiDescription.IsDeprecated();

    ////        if (operation.Parameters == null)
    ////        {
    ////            return;
    ////        }

    ////        foreach (var parameter in operation.Parameters.OfType<NonBodyParameter>())
    ////        {
    ////            var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

    ////            if (parameter.Description == null)
    ////            {
    ////                parameter.Description = description.ModelMetadata?.Description;
    ////            }

    ////            if (parameter.Default == null)
    ////            {
    ////                parameter.Default = description.DefaultValue;
    ////            }

    ////            parameter.Required |= description.IsRequired;
    ////        }
    ////    }
    ////}

    //public class SwaggerAuthorizedMiddleware
    //{
    //    private readonly RequestDelegate _next;

    //    public SwaggerAuthorizedMiddleware(RequestDelegate next)
    //    {
    //        _next = next;
    //    }

    //    public async Task Invoke(HttpContext context)
    //    {
    //        if (context.Request.Path.StartsWithSegments("/swagger")
    //            && !context.User.Identity.IsAuthenticated)
    //        {
    //            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
    //            return;
    //        }

    //        await _next.Invoke(context);
    //    }
    }
}
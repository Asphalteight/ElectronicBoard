using Board.Contracts.Contexts.Accounts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Board.Host.Api.Modules;

/// <summary>
/// Модуль для настройки Swagger.
/// </summary>
public static class SwaggerModule
{
    /// <summary>
    /// Добавление модуля Swagger.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddSwaggerModule(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Заголовок авторизации по JWT используя схему барьера." +
                              "Отправьте 'Bearer' [пробел] и затем ваш токен." +
                              "Пример: 'Bearer key'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
    
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "El Board Api", Version = "V1" });
            options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, $"{typeof(CreateAccountDto).Assembly.GetName().Name}.xml")));
            options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, "Documentation.xml")));
        });
        
        return services;
    }
}
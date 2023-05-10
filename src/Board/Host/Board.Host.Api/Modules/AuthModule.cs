using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Board.Host.Api.Modules;

/// <summary>
/// Модуль для настройки аутентификации и авторизации.
/// </summary>
public static class AuthModule
{
    /// <summary>
    /// Добавление модуля Swagger.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration">Конфигурация</param>
    /// <returns></returns>
    public static IServiceCollection AddAuthModule(this IServiceCollection services, IConfiguration configuration)
    {
        // Аутентификация
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var key = configuration["JWT:Key"];
        
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!))
                };
            });
        
        // Авторизация
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminPolicy", x => { x.RequireClaim("admin"); });
        });
        
        services.AddAuthorization();
        
        return services;
    }
}
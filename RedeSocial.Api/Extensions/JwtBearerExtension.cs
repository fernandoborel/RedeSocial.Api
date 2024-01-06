using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RedeSocial.Api.Security;
using System.Text;

namespace RedeSocial.Api.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar a política de autenticação do projeto
    /// </summary>
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearer(this IServiceCollection services, IConfiguration configuration)
        {
            var securityKey = configuration.GetSection("JwtBearerSettings:SecurityKey").Value;
            var expirationInHours = configuration.GetSection("JwtBearerSettings:ExpirationInHours").Value;

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    //definindo as preferencias para autenticação com TOKEN JWT
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false, //validar o emissor do token
                        ValidateAudience = false, //validar o destinatário do token
                        ValidateLifetime = true, //validar o tempo de expiração do token
                        ValidateIssuerSigningKey = true, //validar a chave secreta utilizada pelo emissor do token
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)) //chave
                    };
                });

            services.AddScoped(map => new JwtBearerSecurity(securityKey, expirationInHours));

            return services;
        }
    }
}
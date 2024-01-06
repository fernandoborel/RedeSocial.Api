using Microsoft.OpenApi.Models;

namespace RedeSocial.Api.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar a documentação gerada pelo Swagger
    /// </summary>
    public static class SwaggerDocExtension
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RedeSocial.Api",
                    Description = "API REST para rede social",
                    Version = "1.0",
                    Contact = new OpenApiContact
                    {
                        Name = "Fernando Borel",
                        Email = "fernandomenezesborel@gmail.com",
                        Url = new Uri("https://github.com/fernandoborel")
                    }
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            return services;

        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/Swagger/v1/swagger.json", "RedeSocialApi");

                // Adiciona o botão para autenticação JWT no Swagger UI
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                options.RoutePrefix = "swagger";
            });

            return app;
        }
    }
}



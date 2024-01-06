using RedeSocial.Domain.Interfaces.Repositories;
using RedeSocial.Domain.Interfaces.Services;
using RedeSocial.Domain.Services;
using RedeSocial.Infra.Data.Repositories;

namespace RedeSocial.Api.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar as injeções de dependência
    /// das interfaces e classes do projeto
    /// </summary>
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            #region Serviços de domínio

            services.AddScoped<IPessoaDomainService, PessoaDomainService>();
            services.AddScoped<IPublicacaoDomainService, PublicacaoDomainService>();

            #endregion

            #region Repositórios

            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();
            services.AddScoped<IComentarioRepository, ComentarioRepository>();

            #endregion

            return services;
        }
    }
}
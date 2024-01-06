using RedeSocial.Domain.Dtos;

namespace RedeSocial.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface de serviços de domínio para a entidade Publicação
    /// </summary>
    public interface IPublicacaoDomainService
    {
        /// <summary>
        /// Serviço de domínio para cadastrar publicação
        /// </summary>
        Task<Guid> Criar(CriarPublicacaoDto dto, Guid autorId);

        /// <summary>
        /// Serviço de domínio para consultar publicação
        /// </summary>
        Task<List<DadosPublicacaoDto>> Consultar();
    }
}
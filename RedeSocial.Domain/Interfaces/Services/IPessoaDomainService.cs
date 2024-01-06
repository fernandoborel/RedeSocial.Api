using RedeSocial.Domain.Dtos;

namespace RedeSocial.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface de serviço de domínio de Pessoa
    /// </summary>
    public interface IPessoaDomainService
    {
        /// <summary>
        /// Método para criar um registro de pessoa
        /// </summary>
        Task<Guid> Criar(CriarPessoaDto dto, string filePath);

        /// <summary>
        /// Método para autenticar um registro
        /// </summary>
        Task<DadosPessoaDto> Autenticar(AutenticarPessoaDto dto);
    }
}

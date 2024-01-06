using RedeSocial.Domain.Dtos;
using RedeSocial.Domain.Models;

namespace RedeSocial.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface de repositório para Publicação
    /// </summary>
    public interface IPublicacaoRepository : IBaseRepository<Publicacao>
    {
        /// <summary>
        /// Método para retornar uma consulta de publicações contendo os dados do autor
        /// </summary>
        Task <List<DadosPublicacaoDto>> GetAllAsync();
    }
}

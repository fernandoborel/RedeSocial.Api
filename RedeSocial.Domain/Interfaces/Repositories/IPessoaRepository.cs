using RedeSocial.Domain.Models;

namespace RedeSocial.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface de repositório para Pessoa
    /// </summary>
    public interface IPessoaRepository : IBaseRepository<Pessoa>
    {
        /// <summary>
        /// Método para retornar um registro através do e-mail
        /// </summary>
        Task<Pessoa> GetAsync(string email);

        /// <summary>
        /// Método para retornar 1 pessoa
        /// </summary>
        Task<Pessoa> GetAsync(string email, string senha);
    }
}

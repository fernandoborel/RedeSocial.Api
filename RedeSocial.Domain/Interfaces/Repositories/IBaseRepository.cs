namespace RedeSocial.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface de repositório genérico
    /// </summary>
    public interface IBaseRepository<TModel> where TModel : class
    {
        Task AddAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task DeleteAsync(TModel model);

        Task<TModel> GetByIdAsync(Guid id);
    }
}

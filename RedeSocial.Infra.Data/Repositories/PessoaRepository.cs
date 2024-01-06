using MongoDB.Driver;
using RedeSocial.Domain.Interfaces.Repositories;
using RedeSocial.Domain.Models;

namespace RedeSocial.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório de dados para Pessoa
    /// </summary>
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        //construtor
        public PessoaRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<Pessoa> GetAsync(string email)
        {
            var filter = Builders<Pessoa>.Filter.Eq("Email", email);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Pessoa> GetAsync(string email, string senha)
        {
            var filter = Builders<Pessoa>.Filter.Eq("Email", email)
                & Builders<Pessoa>.Filter.Eq("Senha", senha);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}

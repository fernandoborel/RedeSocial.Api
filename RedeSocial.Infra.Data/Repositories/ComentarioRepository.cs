using MongoDB.Driver;
using RedeSocial.Domain.Interfaces.Repositories;
using RedeSocial.Domain.Models;

namespace RedeSocial.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório de dados para Comentário
    /// </summary>
    public class ComentarioRepository : BaseRepository<Comentario>, IComentarioRepository
    {
        //construtor
        public ComentarioRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}

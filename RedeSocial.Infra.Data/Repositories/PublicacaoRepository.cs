using MongoDB.Driver;
using RedeSocial.Domain.Dtos;
using RedeSocial.Domain.Interfaces.Repositories;
using RedeSocial.Domain.Models;

namespace RedeSocial.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório de dados para Publicação
    /// </summary>
    public class PublicacaoRepository : BaseRepository<Publicacao>, IPublicacaoRepository
    {
        private readonly IMongoCollection<Pessoa> _pessoasCollection;

        public PublicacaoRepository(IMongoDatabase database)
        : base(database)
        {
            _pessoasCollection = database.GetCollection<Pessoa>("Pessoa");
        }

        public async Task<List<DadosPublicacaoDto>> GetAllAsync()
        {
            var cursor = await Collection.FindAsync(Builders<Publicacao>.Filter.Empty);
            var publicacoes = await cursor.ToListAsync();

            var dadosPublicacaoDtoList = new List<DadosPublicacaoDto>();

            foreach (var publicacao in publicacoes)
            {
                var pessoa = await _pessoasCollection.Find(p => p.Id == publicacao.AutorId).FirstOrDefaultAsync();

                var dadosPublicacaoDto = new DadosPublicacaoDto
                {
                    Id = publicacao.Id,
                    Conteudo = publicacao.Conteudo,
                    DataHoraPublicacao = publicacao.DataHoraPublicacao,
                    Autor = new DadosPessoaDto
                    {
                        Id = pessoa?.Id,
                        Nome = pessoa?.Nome,
                        Email = pessoa?.Email,
                        Foto = pessoa?.Foto,
                        DataHoraCadastro = pessoa?.DataHoraCadastro
                    }
                };

                dadosPublicacaoDtoList.Add(dadosPublicacaoDto);
            }

            return dadosPublicacaoDtoList
                .OrderByDescending(p => p.DataHoraPublicacao)
                .ToList();
        }
    }
}
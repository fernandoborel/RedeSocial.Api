using RedeSocial.Domain.Dtos;
using RedeSocial.Domain.Interfaces.Repositories;
using RedeSocial.Domain.Interfaces.Services;
using RedeSocial.Domain.Models;

namespace RedeSocial.Domain.Services
{
    /// <summary>
    /// Classe para implementar os serviços de dominio de Publicação
    /// </summary>
    public class PublicacaoDomainService : IPublicacaoDomainService
    {
        private readonly IPublicacaoRepository? _publicacaoRepository;

        public PublicacaoDomainService(IPublicacaoRepository? publicacaoRepository)
        {
            _publicacaoRepository = publicacaoRepository;
        }

        public async Task<Guid> Criar(CriarPublicacaoDto dto, Guid autorId)
        {
            var publicacao = new Publicacao
            {
                Id = Guid.NewGuid(),
                Conteudo = dto.Conteudo,
                DataHoraPublicacao = DateTime.Now,
                AutorId = autorId
            };

            await _publicacaoRepository.AddAsync(publicacao);

            return publicacao.Id.Value;
        }

        public async Task<List<DadosPublicacaoDto>> Consultar()
        {
            return await _publicacaoRepository.GetAllAsync();
        }
    }
}
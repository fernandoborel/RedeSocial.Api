using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.Domain.Dtos;
using RedeSocial.Domain.Interfaces.Services;

namespace RedeSocial.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacoesController : ControllerBase
    {
        private readonly IPublicacaoDomainService? _publicacaoDomainService;

        public PublicacoesController(IPublicacaoDomainService? publicacaoDomainService)
        {
            _publicacaoDomainService = publicacaoDomainService;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] CriarPublicacaoDto dto)
        {
            //capturar o conteudo do TOKEN obtido
            //este conteúdo é o ID do usuário autenticado
            var autorId = User.Identity.Name;

            var id = await _publicacaoDomainService.Criar(dto, Guid.Parse(autorId));
            return StatusCode(201, new
            {
                mensagem = "Publicação cadastrada com sucesso.",
                id
            });
        }

        [HttpPost("curtir/{id}")]
        public IActionResult Curtir(Guid id)
        {
            return Ok();
        }

        [HttpGet("obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            var result = await _publicacaoDomainService.Consultar();
            return StatusCode(200, result);
        }
    }
}
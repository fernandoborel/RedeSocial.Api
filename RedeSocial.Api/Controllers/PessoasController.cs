using Microsoft.AspNetCore.Mvc;
using RedeSocial.Api.Security;
using RedeSocial.Domain.Dtos;
using RedeSocial.Domain.Interfaces.Services;

namespace RedeSocial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        //atributo
        private readonly IPessoaDomainService _pessoaDomainService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly JwtBearerSecurity _jwtBearerSecurity;

        //injeção de dependência
        public PessoasController(IPessoaDomainService pessoaDomainService, IWebHostEnvironment webHostEnvironment, JwtBearerSecurity jwtBearerSecurity)
        {
            _pessoaDomainService = pessoaDomainService;
            _webHostEnvironment = webHostEnvironment;
            _jwtBearerSecurity = jwtBearerSecurity;
        }

        [HttpPost("criar")] //api/pessoas/criar
        public async Task<IActionResult> Criar([FromForm] CriarPessoaDto dto)
        {
            //definir o local onde o arquivo será salvo e o seu nome
            var filePath = $"\\pessoas\\fotos\\{Guid.NewGuid()}.png";
            
            //salvando o arquivo dentro da pasta
            using (var stream = new FileStream(_webHostEnvironment?.WebRootPath + filePath, FileMode.Create))
            {
                await dto.Foto.CopyToAsync(stream);
            }

            var id = await _pessoaDomainService.Criar(dto, filePath);
            return StatusCode(201, new
            {
                mensagem = "Pessoa cadastrada com sucesso.",
                id
            });
        }

        [HttpPost("autenticar")] //api/pessoas/autenticar
        public async Task<IActionResult> Autenticar([FromBody] AutenticarPessoaDto dto)
        {
            var result = await _pessoaDomainService.Autenticar(dto);

            return StatusCode(200, new
            {
                mensagem = "Pessoa autenticada com sucesso.",
                result,
                accessToken = _jwtBearerSecurity.GenerateToken(result.Id.Value),
                expiration = _jwtBearerSecurity.GetExpiration()
            });
        }
    }
}
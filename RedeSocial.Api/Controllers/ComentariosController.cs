using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RedeSocial.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        [HttpPost("criar")]
        public IActionResult Criar()
        {
            return Ok();
        }
    }
}
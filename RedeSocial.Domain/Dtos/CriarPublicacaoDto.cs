using System.ComponentModel.DataAnnotations;

namespace RedeSocial.Domain.Dtos
{
    /// <summary>
    /// DTO para capturar os dados de cadastro de publicação
    /// </summary>
    public class CriarPublicacaoDto
    {
        [Required(ErrorMessage ="Informe o nome da publicação.")]
        public string? Conteudo { get; set; }
    }
}

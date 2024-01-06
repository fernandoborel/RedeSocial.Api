using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RedeSocial.Domain.Dtos
{
    /// <summary>
    /// DTO para capturar os dados de cadastro de pessoa
    /// </summary>
    public class CriarPessoaDto
    {

        [LengthAttribute(8, 100, ErrorMessage = "Informe o nome de {1} a {2} caracteres.")]
        [Required(ErrorMessage = "Informe o nome da pessoa.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Informe o endereço de email.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()-_=+[\]{}|;:'<>,.?/]).{8,}$",
            ErrorMessage = "Informe a senha com letras maiúsculas, minúsculas, números, símbolos e pelo menos 8 caracteres.")]
        [Required(ErrorMessage = "Informe a senha de acesso.")]
        public string? Senha { get; set; }

        //TODO: Incluir validação customizada para verificar a extensão da foto
        [Required(ErrorMessage = "Envie sua foto.")]
        [DataType(DataType.Upload)]
        public IFormFile? Foto { get; set; }
    }
}




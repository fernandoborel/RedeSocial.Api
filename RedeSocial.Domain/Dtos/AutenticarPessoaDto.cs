using System.ComponentModel.DataAnnotations;

namespace RedeSocial.Domain.Dtos
{
    /// <summary>
    /// DTO para capturar os dados de autenticação de pessoa
    /// </summary>
    public class AutenticarPessoaDto
    {
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Informe o endereço de email.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()-_=+[\]{}|;:'<>,.?/]).{8,}$",
            ErrorMessage = "Informe a senha com letras maiúsculas, minúsculas, números, símbolos e pelo menos 8 caracteres.")]
        [Required(ErrorMessage = "Informe a senha de acesso.")]
        public string? Senha { get; set; }
    }
}
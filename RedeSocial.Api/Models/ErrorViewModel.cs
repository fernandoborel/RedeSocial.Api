namespace RedeSocial.Api.Models
{
    /// <summary>
    /// Modelo de dados para retornar erros na API
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Código do erro
        /// </summary>
        public int HttpStatus { get; set; }

        /// <summary>
        /// Listagem das mensagens de erro
        /// </summary>
        public List<string>? Errors { get; set; }
    }
}

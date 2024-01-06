namespace RedeSocial.Domain.Dtos
{
    /// <summary>
    /// DTO para retornar dados de consulta de Pessoa
    /// </summary>
    public class DadosPessoaDto
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Foto { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
    }
}
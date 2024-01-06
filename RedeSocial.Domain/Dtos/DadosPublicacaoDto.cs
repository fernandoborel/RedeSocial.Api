namespace RedeSocial.Domain.Dtos
{
    /// <summary>
    /// DTO para retornar dados de consulta de publicação
    /// </summary>
    public class DadosPublicacaoDto
    {
        public Guid? Id { get; set; }
        public string? Conteudo { get; set; }
        public DateTime? DataHoraPublicacao { get; set; }
        public DadosPessoaDto? Autor { get; set; }
    }
}

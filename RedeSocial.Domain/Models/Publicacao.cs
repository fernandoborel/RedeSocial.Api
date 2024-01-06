namespace RedeSocial.Domain.Models
{
    /// <summary>
    /// Modelo de entidade Publicação
    /// </summary>
    public class Publicacao
    {
        public Guid? Id { get; set; }
        public string? Conteudo { get; set; }
        public DateTime? DataHoraPublicacao { get; set; }
        public Guid? AutorId { get; set; }
        public List<Guid>? Comentarios { get; set; }
        public List<Guid>? Curtidas { get; set; }

    }
}

namespace RedeSocial.Domain.Models
{
    /// <summary>
    /// Modelo de entidade Comentário
    /// </summary>
    public class Comentario
    {
        public Guid? Id { get; set; }
        public string? Conteudo { get; set; }
        public DateTime? DataHoraComentario { get; set; }
        public Guid? AutorId { get; set; }
    }
}

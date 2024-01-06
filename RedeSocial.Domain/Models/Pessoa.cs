namespace RedeSocial.Domain.Models
{
    /// <summary>
    /// Modelo de entidade Pessoa
    /// </summary>
    public class Pessoa
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Foto { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public List<Guid>? Amigos { get; set; }
    }
}

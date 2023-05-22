namespace Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime DataDeCadastro { get; protected set; } = DateTime.Now;
        public DateTime? DataDeAlteracao { get; protected set; }
        public DateTime? DataDeExclusao { get; protected set; }
    }
}

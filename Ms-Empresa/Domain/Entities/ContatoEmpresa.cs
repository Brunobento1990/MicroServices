namespace Domain.Entities
{
    public sealed class ContatoEmpresa : BaseEntity
    {
        public string Ddd { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; } = null!;
    }
}

namespace Domain.Entities
{
    public sealed class EnderecoEmpresa : BaseEntity
    {
        public string Cep { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; } = null!;
    }   
}

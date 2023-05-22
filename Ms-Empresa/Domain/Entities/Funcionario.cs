namespace Domain.Entities
{
    public sealed class Funcionario : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataDeNascimento { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public bool EmailVerificado { get; set; } = false;
        public Guid CodigoEmailFerificado { get; set; }
        public bool Adicionar { get; set; } = true;
        public bool Editar { get; set; } = true;
        public bool Excluir { get; set; } = true;
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; } = null!;
    }
}

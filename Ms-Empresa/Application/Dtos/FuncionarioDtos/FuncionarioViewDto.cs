namespace Application.Dtos.FuncionarioDtos
{
    public class FuncionarioViewDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataDeNascimento { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public bool EmailVerificado { get; set; }
        public Guid CodigoEmailFerificado { get; set; }
        public bool Adicionar { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
    }
}

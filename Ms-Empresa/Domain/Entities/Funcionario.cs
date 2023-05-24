using Domain.Validations;

namespace Domain.Entities
{
    public sealed class Funcionario : BaseEntity
    {
        public Funcionario(string nome,
            string cpf,
            DateTime dataDeNascimento,
            string email,
            string senha,
            bool adicionar,
            bool editar,
            bool excluir,
            Guid empresaId)
        {
            const string messageError = "É obrigatório informar";

            Validation(string.IsNullOrEmpty(nome.Trim()), $"{messageError} o nome do funcionário.");
            Validation(string.IsNullOrEmpty(cpf.Trim()), $"{messageError} o cpf do funcionário.");
            Validation(string.IsNullOrEmpty(email.Trim()), $"{messageError} o email do funcionário.");
            Validation(string.IsNullOrEmpty(senha.Trim()), $"{messageError} a senha do funcionário.");
            Validation(senha.Length < 8, "Senha inválida");
            Validation(senha.Length > 100, "Senha inválida");
            ValidationGuid(empresaId, $"{messageError} é obrigatório informar o id da empresa.");

            Nome = nome;
            Cpf = cpf;
            DataDeNascimento = dataDeNascimento;
            Email = email;
            Senha = senha;
            Adicionar = adicionar;
            Editar = editar;
            Excluir = excluir;
            EmpresaId = empresaId;
            Master = false;
            EmailVerificado = false;
            CodigoEmailFerificado = Guid.NewGuid();
        }

        private void ValidationGuid(Guid id, string error)
        {
            DomainExceptionValidationsString.When(id == Guid.Empty, error);
        }
        private void Validation(bool value, string error)
        {
            DomainExceptionValidationsString.When(value, error);
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public bool EmailVerificado { get; private set; }
        public Guid CodigoEmailFerificado { get; private set; }
        public bool Adicionar { get; private set; }
        public bool Editar { get; private set; }
        public bool Excluir { get; private set; }
        public bool Master { get; private set; }
        public Guid EmpresaId { get; private set; }
        public Empresa Empresa { get; set; } = null!;
    }
}

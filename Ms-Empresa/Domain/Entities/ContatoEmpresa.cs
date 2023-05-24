using Domain.Validations;

namespace Domain.Entities
{
    public sealed class ContatoEmpresa : BaseEntity
    {

        public string? Ddd { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; } = null!;
        public ContatoEmpresa()
        {
                
        }
        public ContatoEmpresa(string? ddd, string? telefone, string? email, Guid empresaId)
        {
            const string messageError = "É obrigatório informar";

            Validation($"{telefone}{email}", $"{messageError} o telefone ou o email da empresa.");
            ValidationGuid(empresaId, $"{messageError} é obrigatório informar o id da empresa.");

            Ddd = ddd;
            Telefone = telefone;
            Email = email;
            EmpresaId = empresaId;
        }
        private void ValidationGuid(Guid id, string error)
        {
            DomainExceptionValidationsString.When(id == Guid.Empty, error);
        }
        private void Validation(string value, string error)
        {
            DomainExceptionValidationsString.When(string.IsNullOrEmpty(value), error);
        }
    }
}

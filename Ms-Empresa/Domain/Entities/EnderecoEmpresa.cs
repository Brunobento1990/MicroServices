using Domain.Validations;

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

        public EnderecoEmpresa()
        {
                
        }
        public EnderecoEmpresa(string cep, 
            string rua, 
            string bairro, 
            string cidade, 
            string estado, 
            string numero, 
            Guid empresaId)
        {
            const string messageError = "É obrigatório informar";

            Validation(cep, $"{messageError} o cep da empresa.");
            Validation(rua, $"{messageError} a rua da empresa.");
            Validation(bairro, $"{messageError} o bairro da empresa.");
            Validation(cidade, $"{messageError} a cidade da empresa.");
            Validation(estado, $"{messageError} o estado da empresa.");
            Validation(numero, $"{messageError} o número da empresa.");
            ValidationGuid(empresaId, $"{messageError} é obrigatório informar o id da empresa.");

            Cep = cep;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Numero = numero;
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

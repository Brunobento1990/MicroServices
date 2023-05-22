using Domain.Validations;
using System.Text;

namespace Domain.Entities
{
    public sealed class Empresa : BaseEntity
    {
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; }
        public string? Setor { get; private set; }
        public string? InscricaoEstadual { get; private set; }
        public string? InscricaoMunicipal { get; private set; }
        public bool PagamentoEmDia { get; private set; }
        public EnderecoEmpresa EnderecoEmpresa { get; set; } = null!;
        public List<ContatoEmpresa> ContatosEmpresa { get; set; } = null!;

        
        public Empresa(string razaoSocial, 
            string nomeFantasia, 
            string cnpj, 
            string? setor, 
            string? inscricaoEstadual, 
            string? inscricaoMunicipal)
        {

            const string messageError = "É obrigatório informar";
            Validation(razaoSocial, $"{messageError} a razão social da empresa.");
            Validation(nomeFantasia, $"{messageError} o nome fantasia da empresa.");
            Validation(cnpj, $"{messageError} o CNPJ da empresa.");
            
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Setor = setor;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoMunicipal = inscricaoMunicipal;
            PagamentoEmDia = true;
        }

        private void Validation(string value, string error)
        {
            DomainExceptionValidationsString.When(string.IsNullOrEmpty(value), error);
        }
    }
}

using Application.Dtos.ContatosEmpresaDtos;
using Application.Dtos.EnderecoEmpresaDtos;
using Application.Dtos.FuncionarioDtos;
using System.Text.Json.Serialization;

namespace Application.Dtos.EmpresaDtos
{
    public class EmpresaViewDto
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Setor { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? InscricaoEstadual { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? InscricaoMunicipal { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnderecoEmpresaViewDto? EnderecoEmpresa { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ContatosEmpresaViewDto>? ContatosEmpresa { get; set; }
        public FuncionarioViewDto Funcionario { get; set; } = null!;
    }
}

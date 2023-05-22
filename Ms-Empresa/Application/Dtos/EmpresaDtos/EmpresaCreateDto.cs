using Application.Dtos.ContatosEmpresaDtos;
using Application.Dtos.EnderecoEmpresaDtos;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.EmpresaDtos
{
    public class EmpresaCreateDto
    {
        [Required(ErrorMessage = "É obrigatório informar a razão social da empresa !")]
        [StringLength(100)]
        public string RazaoSocial { get; set; } = string.Empty;
        [Required(ErrorMessage = "É obrigatório informar o nome fantasia da empresa !")]
        [StringLength(100)]
        public string NomeFantasia { get; set; } = string.Empty;
        [Required(ErrorMessage = "É obrigatório informar o CNPJ da empresa !")]
        [StringLength(20)]
        public string Cnpj { get; set; } = string.Empty;
        [StringLength(50)]
        public string? Setor { get; set; }
        [StringLength(20)]
        public string? InscricaoEstadual { get; set; }
        [StringLength(20)]
        public string? InscricaoMunicipal { get; set; }
        public EnderecoEmpresaCreateDto? EnderecoEmpresa { get; set; }
        public List<ContatosEmpresaCreateDto>? ContatosEmpresa { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.EnderecoEmpresaDtos
{
    public class EnderecoEmpresaCreateDto
    {
        [StringLength(8)]
        [Required(ErrorMessage = "É obrigatório informar o CEP da empresa !")]
        public string Cep { get; set; } = string.Empty;
        [StringLength(50)]
        [Required(ErrorMessage = "É obrigatório informar a rua da empresa !")]
        public string Rua { get; set; } = string.Empty;
        [StringLength(20)]
        [Required(ErrorMessage = "É obrigatório informar o bairro da empresa !")]
        public string Bairro { get; set; } = string.Empty;
        [StringLength(50)]
        [Required(ErrorMessage = "É obrigatório informar a cidade da empresa !")]
        public string Cidade { get; set; } = string.Empty;
        [StringLength(2)]
        [Required(ErrorMessage = "É obrigatório informar o estado da empresa !")]
        public string Estado { get; set; } = string.Empty;
        [StringLength(10)]
        [Required(ErrorMessage = "É obrigatório informar o número da empresa !")]
        public string Numero { get; set; } = string.Empty;
    }
}

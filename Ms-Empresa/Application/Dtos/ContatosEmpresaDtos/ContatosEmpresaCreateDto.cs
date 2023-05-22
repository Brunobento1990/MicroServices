using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.ContatosEmpresaDtos
{
    public class ContatosEmpresaCreateDto
    {
        [StringLength(2)]
        [Required(ErrorMessage = "É obrigatório informar o DDD do contato da empresa !")]
        public string Ddd { get; set; } = string.Empty;
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "É obrigatório informar o talafone da empresa !")]
        public string Telefone { get; set; } = string.Empty;
        [StringLength(100)]
        [Required(ErrorMessage = "É obrigatório informar o e-mail da empresa !")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
    }
}

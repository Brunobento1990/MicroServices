using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.ContatosEmpresaDtos
{
    public class ContatosEmpresaCreateDto
    {
        [StringLength(2)]
        public string? Ddd { get; set; } = string.Empty;
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        public string? Telefone { get; set; } = string.Empty;
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; } = string.Empty;
    }
}

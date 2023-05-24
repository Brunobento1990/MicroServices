using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.Dtos.ContatosEmpresaDtos
{
    public class ContatosEmpresaViewDto
    {
        public Guid Id { get; set; }
        [StringLength(2)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Ddd { get; set; } = string.Empty;
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Telefone { get; set; } = string.Empty;
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Email { get; set; } = string.Empty;
    }
}

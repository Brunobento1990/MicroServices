using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.FuncionarioDtos
{
    public class FuncionarioCreateDto
    {
        [StringLength(250)]
        [Required]
        public string Nome { get; set; } = string.Empty;
        [StringLength(20)]
        [Required]
        public string Cpf { get; set; } = string.Empty;
        [Required]
        public DateTime DataDeNascimento { get; set; }
        [StringLength(100)]
        [Required]
        public string Email { get; set; } = string.Empty;
        [StringLength(100)]
        [Required]
        public string Senha { get; set; } = string.Empty;
        public bool Adicionar { get; set; } = true;
        public bool Editar { get; set; } = true;
        public bool Excluir { get; set; } = true;
        [Required]
        public Guid EmpresaId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Informe no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Informe no máximo 200 caracteres")]
        public string Sobrenome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(200, ErrorMessage = "Informe no máximo 200 caracteres")]
        public string Email { get; set; }

        public int EscolaridadeId { get; set; }
        public string? Escolaridade { get; set; }
    }
}

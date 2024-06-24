using System.ComponentModel.DataAnnotations;

namespace ApiCrud.Domain.Dto
{
    public class UsuarioDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Data de Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Ativo é obrigatório.")]
        public bool Ativo { get; set; }
    }
}

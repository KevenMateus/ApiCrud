using System.ComponentModel.DataAnnotations;

namespace ApiCrud.Domain.Dto
{
    public class PostoDto
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.")]
        public required string Endereco { get; set; }

        public IList<VacinaDto>? Vacinas { get; set; }
    }
}

using ApiCrud.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCrud.Domain.Dto
{
    public class VacinaDto
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "CodigoPosto é obrigatório.")]
        public int CodigoPosto { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Fabricante é obrigatório.")]
        public required string Fabricante { get; set; }

        [Required(ErrorMessage = "Lote é obrigatório.")]
        public required string Lote { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatória.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "DataValidade é obrigatória.")]
        public DateTime DataValidade { get; set; }
    }
}

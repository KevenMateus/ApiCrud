using NajaApiCore.Domain.Entities;

namespace ApiCrud.Domain.Entities
{
    public class Vacina : Entity<int>
    {
        public int CodigoPosto { get; set; }

        public required string Nome { get; set; }

        public required string Fabricante { get; set; }

        public required string Lote { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataValidade { get; set; }

        public required Posto Posto { get; set; }
    }
}

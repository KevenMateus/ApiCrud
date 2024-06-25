using NajaApiCore.Domain.Entities;

namespace ApiCrud.Domain.Entities
{
    public class Posto : Entity<int>
    {
        public required string Nome { get; set; }

        public required string Endereco { get; set; }

        public IList<Vacina>? Vacinas { get; set; }
    }
}

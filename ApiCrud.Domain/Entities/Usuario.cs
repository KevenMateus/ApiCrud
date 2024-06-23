using NajaApiCore.Domain.Entities;

namespace ApiCrud.Domain.Entities
{
    public class Usuario : Entity<int>
    {
        public required string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public bool Ativo { get; set; }
    }
}

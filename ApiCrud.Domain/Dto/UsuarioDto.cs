namespace ApiCrud.Domain.Dto
{
    public class UsuarioDto
    {
        public int Codigo { get; set; }

        public required string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public bool Ativo { get; set; }
    }
}

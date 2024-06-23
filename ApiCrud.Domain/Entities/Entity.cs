namespace NajaApiCore.Domain.Entities
{
    public class Entity<TipoCodigo>
    {
        public required TipoCodigo Codigo { get; set; }
    }
}
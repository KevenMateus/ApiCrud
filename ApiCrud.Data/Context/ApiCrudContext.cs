using ApiCrud.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data.Context
{
    public class ApiCrudContext : DbContext
    {
        public ApiCrudContext(DbContextOptions<ApiCrudContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PostoConfig());
            modelBuilder.ApplyConfiguration(new VacinaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
        }
    }
}

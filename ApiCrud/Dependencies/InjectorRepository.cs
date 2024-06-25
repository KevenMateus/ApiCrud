using ApiCrud.Data.Repositories;
using ApiCrud.Domain.Interfaces.Data;

namespace ApiCrud.Dependencies
{
    public static class InjectorRepository
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IPostoRepository, PostoRepository>();
            services.AddScoped<IVacinaRepository, VacinaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}

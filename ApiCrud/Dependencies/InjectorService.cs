using ApiCrud.Domain.Interfaces.Services;
using ApiCrud.Service.Services;

namespace ApiCrud.Dependencies
{
    public static class InjectorService
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IPostoService, PostoService>();
            services.AddScoped<IVacinaService, VacinaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}

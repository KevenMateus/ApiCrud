using ApiCrud.Data.Context;
using ApiCrud.Domain.Entities;
using ApiCrud.Domain.Interfaces.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApiCrudContext _context;

        public UsuarioRepository(ApiCrudContext context) 
            => _context = context;

        public IList<Usuario> ObterTodos()
            => _context.Set<Usuario>().AsNoTracking().ToList();

        public Usuario PesquisarPorCodigo(int id)
            => _context.Set<Usuario>().Where(u => u.Codigo.Equals(id)).AsNoTracking().First();
    }
}

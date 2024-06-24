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

        public void Criar(Usuario usuario)
        {
            _context.Set<Usuario>().Add(usuario);

            _context.SaveChanges();
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Set<Usuario>().Update(usuario);

            _context.SaveChanges();
        }

        public void Remover(Usuario usuario)
        {
            _context.Set<Usuario>().Remove(usuario);

            _context.SaveChanges();
        }
    }
}

using ApiCrud.Data.Context;
using ApiCrud.Domain.Entities;
using ApiCrud.Domain.Interfaces.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data.Repositories
{
    public class PostoRepository : IPostoRepository
    {
        private readonly ApiCrudContext _context;

        public PostoRepository(ApiCrudContext context)
            => _context = context;

        public IList<Posto> ObterTodos()
            => _context.Set<Posto>().Include(p => p.Vacinas).AsNoTracking().ToList();

        public Posto? PesquisarPorCodigo(int id)
            => _context.Set<Posto>().Where(u => u.Codigo.Equals(id)).Include(p=>p.Vacinas).AsNoTracking().FirstOrDefault();

        public void Criar(Posto posto)
        {
            _context.Set<Posto>().Add(posto);

            _context.SaveChanges();
        }

        public void Atualizar(Posto posto)
        {
            _context.Set<Posto>().Update(posto);

            _context.SaveChanges();
        }

        public void Remover(Posto posto)
        {
            _context.Set<Posto>().Remove(posto);

            _context.SaveChanges();
        }

        public Posto? PesquisarPorNome(string nome)
            => _context.Set<Posto>().Where(u => u.Nome.Equals(nome)).AsNoTracking().FirstOrDefault();
    }
}

using ApiCrud.Data.Context;
using ApiCrud.Domain.Entities;
using ApiCrud.Domain.Interfaces.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data.Repositories
{
    public class VacinaRepository : IVacinaRepository
    {
        private readonly ApiCrudContext _context;

        public VacinaRepository(ApiCrudContext context)
            => _context = context;

        public IList<Vacina> ObterTodos()
            => _context.Set<Vacina>().AsNoTracking().ToList();

        public Vacina? PesquisarPorCodigo(int id)
            => _context.Set<Vacina>().Where(u => u.Codigo.Equals(id)).AsNoTracking().FirstOrDefault();

        public void Criar(Vacina vacina)
        {
            _context.Set<Vacina>().Add(vacina);

            _context.SaveChanges();
        }

        public void Atualizar(Vacina vacina)
        {
            _context.Set<Vacina>().Update(vacina);

            _context.SaveChanges();
        }

        public void Remover(Vacina vacina)
        {
            _context.Set<Vacina>().Remove(vacina);

            _context.SaveChanges();
        }

        public Vacina? PesquisarPorLote(string lote)
            => _context.Set<Vacina>().Where(u => u.Lote.Equals(lote)).AsNoTracking().FirstOrDefault();

        public void CriarLista(IList<Vacina> vacinas)
        {
            _context.Set<Vacina>().AddRange(vacinas);

            _context.SaveChanges();
        }
    }
}

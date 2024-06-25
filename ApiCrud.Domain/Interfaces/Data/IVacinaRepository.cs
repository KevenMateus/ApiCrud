using ApiCrud.Domain.Entities;

namespace ApiCrud.Domain.Interfaces.Data
{
    public interface IVacinaRepository
    {
        IList<Vacina> ObterTodos();

        Vacina? PesquisarPorCodigo(int id);

        void Criar(Vacina vacina);

        void Atualizar(Vacina vacina);

        void Remover(Vacina vacina);

        Vacina? PesquisarPorLote(string lote);

        void CriarLista(IList<Vacina> vacinas);
    }
}

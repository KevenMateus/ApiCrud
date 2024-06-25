using ApiCrud.Domain.Entities;

namespace ApiCrud.Domain.Interfaces.Data
{
    public interface IPostoRepository
    {
        IList<Posto> ObterTodos();

        Posto? PesquisarPorCodigo(int id);

        void Criar(Posto posto);

        void Atualizar(Posto posto);

        void Remover(Posto posto);

        Posto? PesquisarPorNome(string nome);
    }
}

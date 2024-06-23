using ApiCrud.Domain.Entities;

namespace ApiCrud.Domain.Interfaces.Data
{
    public interface IUsuarioRepository
    {
        IList<Usuario> ObterTodos();

        Usuario PesquisarPorCodigo(int id);
    }
}

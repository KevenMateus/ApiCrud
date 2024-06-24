using ApiCrud.Domain.Entities;

namespace ApiCrud.Domain.Interfaces.Data
{
    public interface IUsuarioRepository
    {
        IList<Usuario> ObterTodos();

        Usuario PesquisarPorCodigo(int id);

        void Criar(Usuario usuario);

        void Atualizar(Usuario usuario);

        void Remover(Usuario usuario);
    }
}

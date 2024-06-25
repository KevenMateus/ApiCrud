using ApiCrud.Domain.Dto;

namespace ApiCrud.Domain.Interfaces.Services
{
    public interface IPostoService
    {
        IList<PostoDto> ObterTodos();

        PostoDto PesquisarPorCodigo(int id);

        int Criar(PostoDto posto);

        void Atualizar(PostoDto posto);

        void Remover(PostoDto posto);
    }
}

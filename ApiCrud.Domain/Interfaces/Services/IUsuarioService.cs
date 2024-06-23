using ApiCrud.Domain.Dto;

namespace ApiCrud.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        IList<UsuarioDto> ObterTodos();

        UsuarioDto PesquisarPorCodigo(int id);
    }
}

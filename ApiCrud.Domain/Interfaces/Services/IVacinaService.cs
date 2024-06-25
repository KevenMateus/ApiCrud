using ApiCrud.Domain.Dto;

namespace ApiCrud.Domain.Interfaces.Services
{
    public interface IVacinaService
    {
        IList<VacinaDto> ObterTodos();

        VacinaDto PesquisarPorCodigo(int id);

        int Criar(VacinaDto vacina);

        void Criar(IList<VacinaDto> vacinas);

        void Atualizar(VacinaDto vacina);

        void Remover(VacinaDto vacina);
    }
}

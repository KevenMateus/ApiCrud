using ApiCrud.Domain.Dto;
using ApiCrud.Domain.Entities;
using ApiCrud.Domain.Interfaces.Data;
using ApiCrud.Domain.Interfaces.Services;
using AutoMapper;

namespace ApiCrud.Service.Services
{
    public class VacinaService : IVacinaService
    {
        private readonly IMapper _mapper;
        private readonly IVacinaRepository _vacinaRepository;

        public VacinaService(IMapper mapper, IVacinaRepository vacinaRepository)
        {
            _mapper = mapper;
            _vacinaRepository = vacinaRepository;
        }

        public IList<VacinaDto> ObterTodos()
            => _mapper.Map<IList<VacinaDto>>(_vacinaRepository.ObterTodos());

        public VacinaDto PesquisarPorCodigo(int id)
            => _mapper.Map<VacinaDto>(_vacinaRepository.PesquisarPorCodigo(id));

        public int Criar(VacinaDto vacina)
        {
            vacina.Codigo = GetProximoCodigo();

            Vacina? loteVacina = _vacinaRepository.PesquisarPorLote(vacina.Lote);

            ValidarVacina(vacina, loteVacina);

            _vacinaRepository.Criar(_mapper.Map<Vacina>(vacina));

            return vacina.Codigo;
        }

        public void Criar(IList<VacinaDto> vacinas)
        {
            int count = 0;
            foreach (VacinaDto vacina in vacinas)
            {
                vacina.Codigo = (GetProximoCodigo() + count);
                count ++;
            }

            _vacinaRepository.CriarLista(_mapper.Map<IList<Vacina>>(vacinas));
        }

        private static void ValidarVacina(VacinaDto vacina, Vacina? loteVacina)
        {
            if (loteVacina != null)
                throw new InvalidOperationException("Não é possível criar uma vacina pois o lote informado já existe!");

            if (vacina.DataValidade <= DateTime.Now)
                throw new InvalidOperationException("Não é possível criar uma vacina com a data de validade inferior ou igual a data atual!");
        }

        private int GetProximoCodigo()
        {
           int maxCodigo = _vacinaRepository.ObterTodos().Max(c => (int?)c.Codigo) ?? 0;

            return maxCodigo + 1;
        }

        public void Atualizar(VacinaDto vacina)
            => _vacinaRepository.Atualizar(_mapper.Map<Vacina>(vacina));

        public void Remover(VacinaDto vacina)
            => _vacinaRepository.Remover(_mapper.Map<Vacina>(vacina));
    }
}

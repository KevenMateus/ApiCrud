using ApiCrud.Domain.Dto;
using ApiCrud.Domain.Entities;
using ApiCrud.Domain.Interfaces.Data;
using ApiCrud.Domain.Interfaces.Services;
using AutoMapper;

namespace ApiCrud.Service.Services
{
    public class PostoService : IPostoService
    {
        private readonly IMapper _mapper;
        private readonly IPostoRepository _postoRepository;

        public PostoService(IMapper mapper, IPostoRepository postoRepository)
        {
            _mapper = mapper;
            _postoRepository = postoRepository;
        }

        public IList<PostoDto> ObterTodos()
            => _mapper.Map<IList<PostoDto>>(_postoRepository.ObterTodos());

        public PostoDto PesquisarPorCodigo(int id)
            => _mapper.Map<PostoDto>(_postoRepository.PesquisarPorCodigo(id));

        private PostoDto PesquisarPorNome(string nome)
            => _mapper.Map<PostoDto>(_postoRepository.PesquisarPorNome(nome));

        public int Criar(PostoDto posto)
        {
            posto.Codigo = GetProximoCodigo();

            Posto? postoNome = _postoRepository.PesquisarPorNome(posto.Nome);

            if(postoNome != null)
                throw new InvalidOperationException("Não é possível criar. Pois já existe um posto com esse nome!");

            _postoRepository.Criar(_mapper.Map<Posto>(posto));

            return posto.Codigo;
        }

        private int GetProximoCodigo()
            => ObterTodos().Max(c => c.Codigo) + 1;

        public void Atualizar(PostoDto posto)
            => _postoRepository.Atualizar(_mapper.Map<Posto>(posto));

        public void Remover(PostoDto posto)
        {
            Posto? postoVacinas = _postoRepository.PesquisarPorCodigo(posto.Codigo);

                if (postoVacinas != null && postoVacinas.Vacinas != null && postoVacinas.Vacinas.Any())
                throw new InvalidOperationException("Não é possível remover o posto pois existem vacinas associadas a ele!");

            _postoRepository.Remover(_mapper.Map<Posto>(posto));
        }
    }
}

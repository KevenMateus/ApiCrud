using ApiCrud.Domain.Dto;
using ApiCrud.Domain.Interfaces.Data;
using ApiCrud.Domain.Interfaces.Services;
using AutoMapper;

namespace ApiCrud.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public IList<UsuarioDto> ObterTodos()
            => _mapper.Map<IList<UsuarioDto>>(_usuarioRepository.ObterTodos());

        public UsuarioDto PesquisarPorCodigo(int id)
            => _mapper.Map<UsuarioDto>(_usuarioRepository.PesquisarPorCodigo(id));
    }
}

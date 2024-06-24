using ApiCrud.Domain.Dto;
using ApiCrud.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrud.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
            => _usuarioService = usuarioService;

        /// <summary>
        /// Consultar Tdos
        /// </summary>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var usuarios = _usuarioService.ObterTodos();
            return Ok(usuarios);
        }

        /// <summary>
        /// Consulta por código
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpGet("{id}")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = _usuarioService.PesquisarPorCodigo(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        /// <summary>
        /// Criar um novo Usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPost()]
        public IActionResult Create(UsuarioDto usuario)
        {
            int codigo = _usuarioService.Criar(usuario);

            return Ok(new { Message = $"Usuário criado com sucesso! Codigo: {codigo}" });
        }

        /// <summary>
        /// Atualizar Usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPut()]
        public IActionResult Update(UsuarioDto usuario)
        {
            UsuarioDto usuarioAtualizar = _usuarioService.PesquisarPorCodigo(usuario.Codigo);

            if (usuarioAtualizar == null)
                NotFound(new { Message = "Usuário não encontrado" });

            _usuarioService.Atualizar(usuario);

            return Ok(new { Message = $"Usuário atualizado com sucesso!" });
        }

        /// <summary>
        /// Remover
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UsuarioDto usuarioDeletar = _usuarioService.PesquisarPorCodigo(id);

            if (usuarioDeletar == null)
                NotFound(new { Message = "Usuário não encontrado" });
            else
                _usuarioService.Remover(usuario: usuarioDeletar);

            return Ok(new { Message = $"Usuário deletado com sucesso!" });
        }
    }
}

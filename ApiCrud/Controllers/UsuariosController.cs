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
    }
}

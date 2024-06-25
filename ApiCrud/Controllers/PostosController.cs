using ApiCrud.Domain.Dto;
using ApiCrud.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrud.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PostosController : ControllerBase
    {
        private readonly IPostoService _postoService;

        public PostosController(IPostoService postoService)
            => _postoService = postoService;

        /// <summary>
        /// Consultar Todos
        /// </summary>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpGet]
        public IActionResult GetPostos()
        {
            var postos = _postoService.ObterTodos();
            return Ok(postos);
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
        public IActionResult GetPosto(int id)
        {
            var posto = _postoService.PesquisarPorCodigo(id);

            if (posto == null)
                return NotFound(new { Message = "Posto não encontrado" });

            return Ok(posto);
        }

        /// <summary>
        /// Criar um novo Posto
        /// </summary>
        /// <param name="posto"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPost()]
        public IActionResult Create(PostoDto posto)
        {
            int codigo = _postoService.Criar(posto);

            return Ok(new { Message = $"Posto criado com sucesso! Codigo: {codigo}" });
        }

        /// <summary>
        /// Atualizar Posto
        /// </summary>
        /// <param name="posto"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPut()]
        public IActionResult Update(PostoDto posto)
        {
            PostoDto postoAtualizar = _postoService.PesquisarPorCodigo(posto.Codigo);

            if (postoAtualizar == null)
                return NotFound(new { Message = "Posto não encontrado" });

            _postoService.Atualizar(posto);

            return Ok(new { Message = $"Posto atualizado com sucesso!" });
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
            PostoDto postoDeletar = _postoService.PesquisarPorCodigo(id);

            if (postoDeletar == null)
                return NotFound(new { Message = "Posto não encontrado" });
            else
                _postoService.Remover(posto: postoDeletar);

            return Ok(new { Message = $"Posto deletado com sucesso!" });
        }
    }
}

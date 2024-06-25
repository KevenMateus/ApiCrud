using ApiCrud.Domain.Dto;
using ApiCrud.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrud.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class VacinasController : ControllerBase
    {
        private readonly IPostoService _postoService;
        private readonly IVacinaService _vacinaService;

        public VacinasController(IVacinaService vacinaService, IPostoService postoService)
        {
            _postoService = postoService;
            _vacinaService = vacinaService;
        }

        /// <summary>
        /// Consultar Todos
        /// </summary>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpGet]
        public IActionResult GetVacinas()
        {
            var vacinas = _vacinaService.ObterTodos();
            return Ok(vacinas);
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
        public IActionResult GetVacina(int id)
        {
            var vacina = _vacinaService.PesquisarPorCodigo(id);

            if (vacina == null)
                return NotFound(new { Message = "Vacina não encontrada" });

            return Ok(vacina);
        }

        /// <summary>
        /// Criar uma nova Vacina
        /// </summary>
        /// <param name="vacina"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPost()]
        public IActionResult Create(VacinaDto vacina)
        {
            PostoDto posto = _postoService.PesquisarPorCodigo(vacina.CodigoPosto);

            if (posto == null)
                return NotFound(new { Message = "Posto não encontrado" });

            int codigo = _vacinaService.Criar(vacina);

            return Ok(new { Message = $"Vacina criada com sucesso! Codigo: {codigo}" });
        }

        /// <summary>
        /// Criar varias Vacinas
        /// </summary>
        /// <param name="vacinas"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPost("Lista")]
        public IActionResult CreateList(IList<VacinaDto> vacinas)
        {
            foreach (VacinaDto vacina in vacinas)
            {

                PostoDto posto = _postoService.PesquisarPorCodigo(vacina.CodigoPosto);

                if (posto == null)
                    return NotFound(new { Message = "Posto não encontrado" });
            }

            _vacinaService.Criar(vacinas);

            return Ok(new { Message = $"Vacinas criadas com sucesso!" });
        }

        /// <summary>
        /// Atualizar Vacina
        /// </summary>
        /// <param name="vacina"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPut()]
        public IActionResult Update(VacinaDto vacina)
        {
            VacinaDto vacinaAtualizar = _vacinaService.PesquisarPorCodigo(vacina.Codigo);

            if (vacinaAtualizar == null)
                return NotFound(new { Message = "Vacina não encontrada" });

            _vacinaService.Atualizar(vacina);

            return Ok(new { Message = $"Vacina atualizada com sucesso!" });
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
            VacinaDto vacinaDeletar = _vacinaService.PesquisarPorCodigo(id);

            if (vacinaDeletar == null)
                return NotFound(new { Message = "Vacina não encontrada" });
            else
                _vacinaService.Remover(vacina: vacinaDeletar);

            return Ok(new { Message = $"Vacina deletada com sucesso!" });
        }
    }
}

using back_end.Entidades;
using back_end.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController: ControllerBase
    {
        private IRepositorio repositorio;

        public GenerosController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet] // api/generos
        [HttpGet("listado")] // api/generos/listado
        public ActionResult<List<Genero>> Get()
        {
            return repositorio.ObtenerTodosLosGeneros();
        }

        [HttpGet("{Id:int}")] // api/generos/1
        public async Task<ActionResult<Genero>> Get(int Id, string nombre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genero = await repositorio.ObtenerPorId(Id);

            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }
        
        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Genero genero)
        {
            return NoContent();
        }
    }
}

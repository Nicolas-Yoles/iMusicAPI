using back_end.Entidades;
using back_end.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace back_end.Controllers
{
    [Route("api/generos")]
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

        [HttpGet("{Id:int}/{nombre=Roberto")] // api/generos/1
        public ActionResult<Genero> Get(int Id, string nombre)
        {
            var genero = repositorio.ObtenerPorId(Id);

            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }
        
        [HttpPost]
        public ActionResult Post()
        {
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put()
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }
    }
}
